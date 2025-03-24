"""
InnoSenT Tracker Python Wrapper
===============================

This module provides a Python interface to the InnoSenT tracker library (.so)
"""

import ctypes
import os
import sys
from enum import IntEnum
from typing import List, Tuple, Optional


# Define the basic types from bt_basic_types.h
class BasicTypes:
    sint8_it = ctypes.c_char
    uint8_it = ctypes.c_ubyte
    sint16_it = ctypes.c_short
    uint16_it = ctypes.c_ushort
    sint32_it = ctypes.c_int
    uint32_it = ctypes.c_uint
    uint64_it = ctypes.c_ulonglong
    sint64_it = ctypes.c_longlong
    float32_it = ctypes.c_float
    float64_it = ctypes.c_longdouble
    bool_it = ctypes.c_ushort  # as defined in bt_basic_types.h


# Enums from bt_structs_if.h
class ProductCode(IntEnum):
    BT_PRODUCT_iSYS5011 = 5011
    BT_PRODUCT_iSYS5021 = 5021


class TrackClass(IntEnum):
    BT_TRACK_CLASS_UNCLASSIFIED = 0
    BT_TRACK_CLASS_PEDESTRIAN = 1
    BT_TRACK_CLASS_VEHICLE = 2
    BT_TRACK_CLASS_OTHER = 3


class ParameterType(IntEnum):
    # Version
    BT_PARAMETER_UI32_VERSION_MAJOR = 0x0001
    BT_PARAMETER_UI32_VERSION_FIXED = 0x0002
    BT_PARAMETER_UI32_VERSION_MINOR = 0x0003
    BT_PARAMETER_UI32_VERSION_DATE = 0x0004
    BT_PARAMETER_UI32_COMPILE_DATE = 0x0005
    
    # Wind Filter
    BT_PARAMETER_F32_WIND_FILTER_DISTANCE = 0x0410
    BT_PARAMETER_UI16_WIND_FILTER_ACTIVE = 0x0411


class ITLResult(IntEnum):
    ITL_OK = 0
    ITL_ERROR_PROCESSING = 1
    ITL_ERROR_MEMORY_ALLOCATION = 2
    ITL_ERROR_PARAMETER = 3
    ITL_ERROR_STRUCT_SIZE = 4
    ITL_ERROR_PRODUCT_CODE = 5


# Constants from bt_structs_if.h
BT_MAX_NR_OF_TARGETS = 256
BT_MAX_NR_OF_TRACKS = 64
BT_MAX_NR_OF_IGNORE_ZONES = 10
BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE = 10


# Define structs from header files
class Vector2DFloat(ctypes.Structure):
    _fields_ = [
        ("x", BasicTypes.float32_it),
        ("y", BasicTypes.float32_it)
    ]


class TargetListRV(ctypes.Structure):
    _fields_ = [
        ("f32_rcs_m2", BasicTypes.float32_it),
        ("f32_range_m", BasicTypes.float32_it),
        ("f32_velocity_mps", BasicTypes.float32_it),
        ("f32_angleAzimuth_deg", BasicTypes.float32_it),
        ("f32_reserved1", BasicTypes.float32_it),
        ("f32_reserved2", BasicTypes.float32_it)
    ]


class ExtTrackList(ctypes.Structure):
    _fields_ = [
        ("ui32_objectID", BasicTypes.uint32_it),
        ("ui16_ageCount", BasicTypes.uint16_it),
        ("ui16_predictionCount", BasicTypes.uint16_it),
        ("ui16_staticCount", BasicTypes.uint16_it),
        ("f32_trackQuality", BasicTypes.float32_it),
        ("classID", ctypes.c_uint),  # Enum bt_track_class_t
        ("f32_positionX_m", BasicTypes.float32_it),
        ("f32_positionY_m", BasicTypes.float32_it),
        ("f32_velocityX_mps", BasicTypes.float32_it),
        ("f32_velocityY_mps", BasicTypes.float32_it),
        ("f32_directionX", BasicTypes.float32_it),
        ("f32_directionY", BasicTypes.float32_it)
    ]


class IgnoreZone(ctypes.Structure):
    _fields_ = [
        ("b_active", BasicTypes.bool_it),
        ("ui16_nrOfVertices", BasicTypes.uint16_it),
        ("v2d_min", Vector2DFloat),
        ("v2d_max", Vector2DFloat),
        ("v2d_vertex", Vector2DFloat * BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE)
    ]


class TrackerException(Exception):
    """Exception raised for errors in the tracker library."""
    def __init__(self, result_code):
        self.result_code = result_code
        super().__init__(f"Tracker error: {ITLResult(result_code).name}")


class InnoSenTTracker:
    """Python wrapper for the InnoSenT tracker library."""
    
    def __init__(self, library_path: str):
        """
        Initialize the tracker library.
        
        Args:
            library_path: Path to the shared library (.so) file
        """
        try:
            self.lib = ctypes.CDLL(library_path)
        except OSError as e:
            raise RuntimeError(f"Failed to load library from {library_path}: {e}")
        
        # Set return and argument types for all functions
        self._setup_function_prototypes()
    
    def _setup_function_prototypes(self):
        """Set up the function prototypes for the library."""
        # itl_init_tracker
        self.lib.itl_init_tracker.argtypes = [BasicTypes.float32_it]
        self.lib.itl_init_tracker.restype = ctypes.c_int  # ITLResult_t
        
        # itl_execute_tracker
        self.lib.itl_execute_tracker.argtypes = [
            ctypes.POINTER(TargetListRV),
            BasicTypes.uint16_it
        ]
        self.lib.itl_execute_tracker.restype = ctypes.c_int
        
        # itl_receive_track_list
        self.lib.itl_receive_track_list.argtypes = [
            ctypes.POINTER(ExtTrackList),
            ctypes.POINTER(BasicTypes.uint16_it)
        ]
        self.lib.itl_receive_track_list.restype = ctypes.c_int
        
        # itl_set_ignore_zones
        self.lib.itl_set_ignore_zones.argtypes = [
            ctypes.POINTER(IgnoreZone),
            BasicTypes.uint16_it
        ]
        self.lib.itl_set_ignore_zones.restype = ctypes.c_int
        
        # itl_get_ignore_zones
        self.lib.itl_get_ignore_zones.argtypes = [ctypes.POINTER(IgnoreZone)]
        self.lib.itl_get_ignore_zones.restype = ctypes.c_int
        
        # itl_reset_tracks
        self.lib.itl_reset_tracks.argtypes = []
        self.lib.itl_reset_tracks.restype = ctypes.c_int
        
        # itl_set_default_values
        self.lib.itl_set_default_values.argtypes = [ctypes.c_uint]  # BTProductCode_t
        self.lib.itl_set_default_values.restype = ctypes.c_int
        
        # itl_set_installation_height
        self.lib.itl_set_installation_height.argtypes = [BasicTypes.float32_it]
        self.lib.itl_set_installation_height.restype = ctypes.c_int
        
        # itl_get_installation_height
        self.lib.itl_get_installation_height.argtypes = [ctypes.POINTER(BasicTypes.float32_it)]
        self.lib.itl_get_installation_height.restype = ctypes.c_int
        
        # itl_set_installation_angle
        self.lib.itl_set_installation_angle.argtypes = [BasicTypes.float32_it]
        self.lib.itl_set_installation_angle.restype = ctypes.c_int
        
        # itl_get_installation_angle
        self.lib.itl_get_installation_angle.argtypes = [ctypes.POINTER(BasicTypes.float32_it)]
        self.lib.itl_get_installation_angle.restype = ctypes.c_int
        
        # Parameter getters/setters
        self.lib.itl_set_parameter_f32.argtypes = [ctypes.c_int, BasicTypes.float32_it]
        self.lib.itl_set_parameter_f32.restype = ctypes.c_int
        
        self.lib.itl_set_parameter_ui16.argtypes = [ctypes.c_int, BasicTypes.uint16_it]
        self.lib.itl_set_parameter_ui16.restype = ctypes.c_int
        
        self.lib.itl_set_parameter_si16.argtypes = [ctypes.c_int, BasicTypes.sint16_it]
        self.lib.itl_set_parameter_si16.restype = ctypes.c_int
        
        self.lib.itl_get_parameter_f32.argtypes = [ctypes.c_int, ctypes.POINTER(BasicTypes.float32_it)]
        self.lib.itl_get_parameter_f32.restype = ctypes.c_int
        
        self.lib.itl_get_parameter_ui16.argtypes = [ctypes.c_int, ctypes.POINTER(BasicTypes.uint16_it)]
        self.lib.itl_get_parameter_ui16.restype = ctypes.c_int
        
        self.lib.itl_get_parameter_ui32.argtypes = [ctypes.c_int, ctypes.POINTER(BasicTypes.uint32_it)]
        self.lib.itl_get_parameter_ui32.restype = ctypes.c_int
        
        self.lib.itl_get_parameter_si16.argtypes = [ctypes.c_int, ctypes.POINTER(BasicTypes.sint16_it)]
        self.lib.itl_get_parameter_si16.restype = ctypes.c_int

    def _check_result(self, result):
        """Check the result code and raise an exception if it's not ITL_OK."""
        if result != ITLResult.ITL_OK:
            raise TrackerException(result)
        return result

    def init_tracker(self, cycle_time_s: float) -> None:
        """
        Initialize the tracker with the given cycle time.
        
        Args:
            cycle_time_s: Cycle time in seconds
        """
        result = self.lib.itl_init_tracker(cycle_time_s)
        self._check_result(result)
    
    def execute_tracker(self, targets: List[dict]) -> None:
        """
        Execute the tracker with the given target list.
        
        Args:
            targets: List of target dictionaries with the following keys:
                - rcs_m2: RCS in m²
                - range_m: Range in m
                - velocity_mps: Velocity in m/s
                - angle_azimuth_deg: Azimuth angle in degrees
        """
        num_targets = len(targets)
        if num_targets > BT_MAX_NR_OF_TARGETS:
            raise ValueError(f"Too many targets: {num_targets} > {BT_MAX_NR_OF_TARGETS}")
        
        target_array = (TargetListRV * num_targets)()
        
        for i, target in enumerate(targets):
            target_array[i].f32_rcs_m2 = target.get('rcs_m2', 0.0)
            target_array[i].f32_range_m = target.get('range_m', 0.0)
            target_array[i].f32_velocity_mps = target.get('velocity_mps', 0.0)
            target_array[i].f32_angleAzimuth_deg = target.get('angle_azimuth_deg', 0.0)
            target_array[i].f32_reserved1 = 0.0
            target_array[i].f32_reserved2 = 0.0
        
        result = self.lib.itl_execute_tracker(target_array, num_targets)
        self._check_result(result)
    
    def receive_track_list(self) -> List[dict]:
        """
        Receive the track list from the tracker.
        
        Returns:
            List of track dictionaries
        """
        tracks_array = (ExtTrackList * BT_MAX_NR_OF_TRACKS)()
        num_tracks = BasicTypes.uint16_it(0)
        
        result = self.lib.itl_receive_track_list(tracks_array, ctypes.byref(num_tracks))
        self._check_result(result)
        
        tracks = []
        for i in range(num_tracks.value):
            track = {
                'object_id': tracks_array[i].ui32_objectID,
                'age_count': tracks_array[i].ui16_ageCount,
                'prediction_count': tracks_array[i].ui16_predictionCount,
                'static_count': tracks_array[i].ui16_staticCount,
                'track_quality': tracks_array[i].f32_trackQuality,
                'class_id': TrackClass(tracks_array[i].classID),
                'position_x_m': tracks_array[i].f32_positionX_m,
                'position_y_m': tracks_array[i].f32_positionY_m,
                'velocity_x_mps': tracks_array[i].f32_velocityX_mps,
                'velocity_y_mps': tracks_array[i].f32_velocityY_mps,
                'direction_x': tracks_array[i].f32_directionX,
                'direction_y': tracks_array[i].f32_directionY
            }
            tracks.append(track)
        
        return tracks
    
    def set_ignore_zones(self, ignore_zones: List[dict]) -> None:
        """
        Set the ignore zones.
        
        Args:
            ignore_zones: List of ignore zone dictionaries with the following keys:
                - active: Boolean indicating if the zone is active
                - vertices: List of (x, y) tuples representing the vertices of the zone
        """
        num_zones = len(ignore_zones)
        if num_zones > BT_MAX_NR_OF_IGNORE_ZONES:
            raise ValueError(f"Too many ignore zones: {num_zones} > {BT_MAX_NR_OF_IGNORE_ZONES}")
        
        zones_array = (IgnoreZone * num_zones)()
        
        for i, zone in enumerate(ignore_zones):
            vertices = zone.get('vertices', [])
            num_vertices = len(vertices)
            
            if num_vertices > BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE:
                raise ValueError(f"Too many vertices in zone {i}: {num_vertices} > {BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE}")
            
            zones_array[i].b_active = 1 if zone.get('active', False) else 0
            zones_array[i].ui16_nrOfVertices = num_vertices
            
            # Calculate min/max for faster checks
            min_x = min(v[0] for v in vertices) if vertices else 0.0
            min_y = min(v[1] for v in vertices) if vertices else 0.0
            max_x = max(v[0] for v in vertices) if vertices else 0.0
            max_y = max(v[1] for v in vertices) if vertices else 0.0
            
            zones_array[i].v2d_min.x = min_x
            zones_array[i].v2d_min.y = min_y
            zones_array[i].v2d_max.x = max_x
            zones_array[i].v2d_max.y = max_y
            
            for j, (x, y) in enumerate(vertices):
                zones_array[i].v2d_vertex[j].x = x
                zones_array[i].v2d_vertex[j].y = y
        
        result = self.lib.itl_set_ignore_zones(zones_array, num_zones)
        self._check_result(result)
    
    def get_ignore_zones(self) -> List[dict]:
        """
        Get the current ignore zones.
        
        Returns:
            List of ignore zone dictionaries
        """
        zones_array = (IgnoreZone * BT_MAX_NR_OF_IGNORE_ZONES)()
        
        result = self.lib.itl_get_ignore_zones(zones_array)
        self._check_result(result)
        
        zones = []
        for i in range(BT_MAX_NR_OF_IGNORE_ZONES):
            zone = zones_array[i]
            if zone.ui16_nrOfVertices > 0:
                vertices = []
                for j in range(zone.ui16_nrOfVertices):
                    vertices.append((zone.v2d_vertex[j].x, zone.v2d_vertex[j].y))
                
                zones.append({
                    'active': bool(zone.b_active),
                    'vertices': vertices,
                    'min': (zone.v2d_min.x, zone.v2d_min.y),
                    'max': (zone.v2d_max.x, zone.v2d_max.y)
                })
        
        return zones
    
    def reset_tracks(self) -> None:
        """Reset all tracks."""
        result = self.lib.itl_reset_tracks()
        self._check_result(result)
    
    def set_default_values(self, product_code: ProductCode) -> None:
        """
        Set default values for the given product code.
        
        Args:
            product_code: Product code from ProductCode enum
        """
        result = self.lib.itl_set_default_values(product_code)
        self._check_result(result)
    
    def set_installation_height(self, height: float) -> None:
        """
        Set the installation height.
        
        Args:
            height: Installation height in meters
        """
        result = self.lib.itl_set_installation_height(height)
        self._check_result(result)
    
    def get_installation_height(self) -> float:
        """
        Get the installation height.
        
        Returns:
            Installation height in meters
        """
        height = BasicTypes.float32_it()
        result = self.lib.itl_get_installation_height(ctypes.byref(height))
        self._check_result(result)
        return height.value
    
    def set_installation_angle(self, angle: float) -> None:
        """
        Set the installation angle.
        
        Args:
            angle: Installation angle in degrees
        """
        result = self.lib.itl_set_installation_angle(angle)
        self._check_result(result)
    
    def get_installation_angle(self) -> float:
        """
        Get the installation angle.
        
        Returns:
            Installation angle in degrees
        """
        angle = BasicTypes.float32_it()
        result = self.lib.itl_get_installation_angle(ctypes.byref(angle))
        self._check_result(result)
        return angle.value
    
    def set_parameter_float(self, param_type: ParameterType, value: float) -> None:
        """
        Set a float parameter.
        
        Args:
            param_type: Parameter type from ParameterType enum
            value: Parameter value
        """
        result = self.lib.itl_set_parameter_f32(param_type, value)
        self._check_result(result)
    
    def set_parameter_uint16(self, param_type: ParameterType, value: int) -> None:
        """
        Set a uint16 parameter.
        
        Args:
            param_type: Parameter type from ParameterType enum
            value: Parameter value
        """
        result = self.lib.itl_set_parameter_ui16(param_type, value)
        self._check_result(result)
    
    def set_parameter_int16(self, param_type: ParameterType, value: int) -> None:
        """
        Set a sint16 parameter.
        
        Args:
            param_type: Parameter type from ParameterType enum
            value: Parameter value
        """
        result = self.lib.itl_set_parameter_si16(param_type, value)
        self._check_result(result)
    
    def get_parameter_float(self, param_type: ParameterType) -> float:
        """
        Get a float parameter.
        
        Args:
            param_type: Parameter type from ParameterType enum
            
        Returns:
            Parameter value
        """
        value = BasicTypes.float32_it()
        result = self.lib.itl_get_parameter_f32(param_type, ctypes.byref(value))
        self._check_result(result)
        return value.value
    
    def get_parameter_uint16(self, param_type: ParameterType) -> int:
        """
        Get a uint16 parameter.
        
        Args:
            param_type: Parameter type from ParameterType enum
            
        Returns:
            Parameter value
        """
        value = BasicTypes.uint16_it()
        result = self.lib.itl_get_parameter_ui16(param_type, ctypes.byref(value))
        self._check_result(result)
        return value.value
    
    def get_parameter_uint32(self, param_type: ParameterType) -> int:
        """
        Get a uint32 parameter.
        
        Args:
            param_type: Parameter type from ParameterType enum
            
        Returns:
            Parameter value
        """
        value = BasicTypes.uint32_it()
        result = self.lib.itl_get_parameter_ui32(param_type, ctypes.byref(value))
        self._check_result(result)
        return value.value
    
    def get_parameter_int16(self, param_type: ParameterType) -> int:
        """
        Get a sint16 parameter.
        
        Args:
            param_type: Parameter type from ParameterType enum
            
        Returns:
            Parameter value
        """
        value = BasicTypes.sint16_it()
        result = self.lib.itl_get_parameter_si16(param_type, ctypes.byref(value))
        self._check_result(result)
        return value.value
    
def main():
    tracker = InnoSenTTracker('./InnoSenT_Tracker_Library/Linux_aarch64/libitl.so')

    result_init = tracker.init_tracker(0.1)
    print(f"init_tracker result: {result_init}")

    result_default_values = tracker.set_default_values(ProductCode.BT_PRODUCT_iSYS5021)
    print(f"set_default_values result: {result_default_values}")

if __name__ == "__main__":
    main()
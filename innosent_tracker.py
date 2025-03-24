# innosent_tracker.py
# Python wrapper for InnoSenT Tracker Library (.so file)
# Based on the header files:
# - bt_basic_types.h
# - bt_structs_if.h
# - itl_if.h

import ctypes
import os
import enum
from typing import List, Tuple

class BTProductCode(enum.IntEnum):
    """Product code enumeration"""
    BT_PRODUCT_iSYS5011 = 5011
    BT_PRODUCT_iSYS5021 = 5021

class BTTrackClass(enum.IntEnum):
    """Track class enumeration"""
    BT_TRACK_CLASS_UNCLASSIFIED = 0
    BT_TRACK_CLASS_PEDESTRIAN = 1
    BT_TRACK_CLASS_VEHICLE = 2
    BT_TRACK_CLASS_OTHER = 3

class BTParameter(enum.IntEnum):
    """Parameter enumeration for get/set operations"""
    # Version
    BT_PARAMETER_UI32_VERSION_MAJOR = 0x0001
    BT_PARAMETER_UI32_VERSION_FIXED = 0x0002
    BT_PARAMETER_UI32_VERSION_MINOR = 0x0003
    BT_PARAMETER_UI32_VERSION_DATE = 0x0004
    BT_PARAMETER_UI32_COMPILE_DATE = 0x0005
    
    # Wind Filter
    BT_PARAMETER_F32_WIND_FILTER_DISTANCE = 0x0410
    BT_PARAMETER_UI16_WIND_FILTER_ACTIVE = 0x0411

class ITLResult(enum.IntEnum):
    """Result codes from tracker operations"""
    ITL_OK = 0
    ITL_ERROR_PROCESSING = 1
    ITL_ERROR_MEMORY_ALLOCATION = 2
    ITL_ERROR_PARAMETER = 3
    ITL_ERROR_STRUCT_SIZE = 4
    ITL_ERROR_PRODUCT_CODE = 5


class Vector2D(ctypes.Structure):
    """2D vector structure"""
    _fields_ = [
        ("x", ctypes.c_float),
        ("y", ctypes.c_float)
    ]


class BTTargetListRV(ctypes.Structure):
    """RV target list received from sensor"""
    _fields_ = [
        ("f32_rcs_m2", ctypes.c_float),          # [m²]
        ("f32_range_m", ctypes.c_float),         # [m]
        ("f32_velocity_mps", ctypes.c_float),    # [m/s]
        ("f32_angleAzimuth_deg", ctypes.c_float),# [deg]
        ("f32_reserved1", ctypes.c_float),
        ("f32_reserved2", ctypes.c_float)
    ]


class BTExtTrackList(ctypes.Structure):
    """External track list"""
    _fields_ = [
        # Track identifier
        ("ui32_objectID", ctypes.c_uint32),
        # Additional states
        ("ui16_ageCount", ctypes.c_uint16),
        ("ui16_predictionCount", ctypes.c_uint16),
        ("ui16_staticCount", ctypes.c_uint16),
        ("f32_trackQuality", ctypes.c_float),
        ("classID", ctypes.c_int),  # Using c_int for enum type
        # Track position and velocity
        ("f32_positionX_m", ctypes.c_float),
        ("f32_positionY_m", ctypes.c_float),
        ("f32_velocityX_mps", ctypes.c_float),
        ("f32_velocityY_mps", ctypes.c_float),
        ("f32_directionX", ctypes.c_float),
        ("f32_directionY", ctypes.c_float)
    ]


class BTIgnoreZone(ctypes.Structure):
    """Ignore zone structure"""
    BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE = 10
    
    _fields_ = [
        ("b_active", ctypes.c_ushort),  # bool_it is defined as unsigned short
        ("ui16_nrOfVertices", ctypes.c_uint16),
        ("v2d_min", Vector2D),  # Optimization for faster ignore zone check
        ("v2d_max", Vector2D),  # Optimization for faster ignore zone check
        ("v2d_vertex", Vector2D * BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE)  # Polygon vertex points
    ]


class InnoSenTTracker:
    """Python wrapper for InnoSenT Tracker Library"""
    
    # Constants from the header files
    BT_MAX_NR_OF_TARGETS = 256
    BT_MAX_NR_OF_TRACKS = 64
    BT_MAX_NR_OF_IGNORE_ZONES = 10
    BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE = 10
    
    def __init__(self, lib_path: str = './libitl.so'):
        """Initialize the wrapper by loading the shared library
        
        Args:
            lib_path: Path to the .so library
        """
        # Load the shared library
        self.lib = ctypes.CDLL(lib_path)
        
        # Define function prototypes
        
        # itl_init_tracker
        self.lib.itl_init_tracker.argtypes = [ctypes.c_float]
        self.lib.itl_init_tracker.restype = ctypes.c_int
        
        # itl_execute_tracker
        self.lib.itl_execute_tracker.argtypes = [ctypes.POINTER(BTTargetListRV), ctypes.c_uint16]
        self.lib.itl_execute_tracker.restype = ctypes.c_int
        
        # itl_receive_track_list
        self.lib.itl_receive_track_list.argtypes = [ctypes.POINTER(BTExtTrackList), ctypes.POINTER(ctypes.c_uint16)]
        self.lib.itl_receive_track_list.restype = ctypes.c_int
        
        # itl_set_ignore_zones
        self.lib.itl_set_ignore_zones.argtypes = [ctypes.POINTER(BTIgnoreZone), ctypes.c_uint16]
        self.lib.itl_set_ignore_zones.restype = ctypes.c_int
        
        # itl_get_ignore_zones
        self.lib.itl_get_ignore_zones.argtypes = [ctypes.POINTER(BTIgnoreZone)]
        self.lib.itl_get_ignore_zones.restype = ctypes.c_int
        
        # itl_reset_tracks
        self.lib.itl_reset_tracks.argtypes = []
        self.lib.itl_reset_tracks.restype = ctypes.c_int
        
        # itl_set_default_values
        self.lib.itl_set_default_values.argtypes = [ctypes.c_int]  # Using c_int for enum
        self.lib.itl_set_default_values.restype = ctypes.c_int
        
        # itl_set_installation_height
        self.lib.itl_set_installation_height.argtypes = [ctypes.c_float]
        self.lib.itl_set_installation_height.restype = ctypes.c_int
        
        # itl_get_installation_height
        self.lib.itl_get_installation_height.argtypes = [ctypes.POINTER(ctypes.c_float)]
        self.lib.itl_get_installation_height.restype = ctypes.c_int
        
        # itl_set_installation_angle
        self.lib.itl_set_installation_angle.argtypes = [ctypes.c_float]
        self.lib.itl_set_installation_angle.restype = ctypes.c_int
        
        # itl_get_installation_angle
        self.lib.itl_get_installation_angle.argtypes = [ctypes.POINTER(ctypes.c_float)]
        self.lib.itl_get_installation_angle.restype = ctypes.c_int
        
        # itl_set_parameter_f32
        self.lib.itl_set_parameter_f32.argtypes = [ctypes.c_int, ctypes.c_float]  # Using c_int for enum
        self.lib.itl_set_parameter_f32.restype = ctypes.c_int
        
        # itl_set_parameter_ui16
        self.lib.itl_set_parameter_ui16.argtypes = [ctypes.c_int, ctypes.c_uint16]  # Using c_int for enum
        self.lib.itl_set_parameter_ui16.restype = ctypes.c_int
        
        # itl_set_parameter_si16
        self.lib.itl_set_parameter_si16.argtypes = [ctypes.c_int, ctypes.c_int16]  # Using c_int for enum
        self.lib.itl_set_parameter_si16.restype = ctypes.c_int
        
        # itl_get_parameter_f32
        self.lib.itl_get_parameter_f32.argtypes = [ctypes.c_int, ctypes.POINTER(ctypes.c_float)]  # Using c_int for enum
        self.lib.itl_get_parameter_f32.restype = ctypes.c_int
        
        # itl_get_parameter_ui16
        self.lib.itl_get_parameter_ui16.argtypes = [ctypes.c_int, ctypes.POINTER(ctypes.c_uint16)]  # Using c_int for enum
        self.lib.itl_get_parameter_ui16.restype = ctypes.c_int
        
        # itl_get_parameter_ui32
        self.lib.itl_get_parameter_ui32.argtypes = [ctypes.c_int, ctypes.POINTER(ctypes.c_uint32)]  # Using c_int for enum
        self.lib.itl_get_parameter_ui32.restype = ctypes.c_int
        
        # itl_get_parameter_si16
        self.lib.itl_get_parameter_si16.argtypes = [ctypes.c_int, ctypes.POINTER(ctypes.c_int16)]  # Using c_int for enum
        self.lib.itl_get_parameter_si16.restype = ctypes.c_int
    
    def init_tracker(self, cycle_time_s: float) -> ITLResult:
        """Initialize the tracker with the given cycle time
        
        Args:
            cycle_time_s: Cycle time of the sensor in seconds
            
        Returns:
            Result code
        """
        result = self.lib.itl_init_tracker(ctypes.c_float(cycle_time_s))
        return ITLResult(result)
    
    def set_default_values(self, product_code: BTProductCode) -> ITLResult:
        """Set default values for the tracker based on the product code
        
        Args:
            product_code: Product code
            
        Returns:
            Result code
        """
        result = self.lib.itl_set_default_values(ctypes.c_int(product_code))
        return ITLResult(result)
    
    def execute_tracker(self, target_list: List[dict]) -> ITLResult:
        """Execute the tracker with the given target list
        
        Args:
            target_list: List of target dictionaries, each containing:
                - rcs_m2: Radar Cross Section in m²
                - range_m: Range in meters
                - velocity_mps: Velocity in meters per second
                - angle_azimuth_deg: Azimuth angle in degrees
                
        Returns:
            Result code
        """
        # Convert Python list to C array
        nr_of_targets = len(target_list)
        targets_array = (BTTargetListRV * nr_of_targets)()
        
        for i, target in enumerate(target_list):
            targets_array[i].f32_rcs_m2 = target.get('rcs_m2', 0.0)
            targets_array[i].f32_range_m = target.get('range_m', 0.0)
            targets_array[i].f32_velocity_mps = target.get('velocity_mps', 0.0)
            targets_array[i].f32_angleAzimuth_deg = target.get('angle_azimuth_deg', 0.0)
            targets_array[i].f32_reserved1 = 0.0
            targets_array[i].f32_reserved2 = 0.0
        
        result = self.lib.itl_execute_tracker(targets_array, ctypes.c_uint16(nr_of_targets))
        return ITLResult(result)
    
    def receive_track_list(self) -> Tuple[ITLResult, List[dict]]:
        """Receive the current track list from the tracker
        
        Returns:
            Tuple containing:
                - Result code
                - List of track dictionaries
        """
        tracks = (BTExtTrackList * self.BT_MAX_NR_OF_TRACKS)()
        nr_of_tracks = ctypes.c_uint16(0)
        
        result = self.lib.itl_receive_track_list(tracks, ctypes.byref(nr_of_tracks))
        
        track_list = []
        for i in range(nr_of_tracks.value):
            track = {
                'object_id': tracks[i].ui32_objectID,
                'age_count': tracks[i].ui16_ageCount,
                'prediction_count': tracks[i].ui16_predictionCount,
                'static_count': tracks[i].ui16_staticCount,
                'track_quality': tracks[i].f32_trackQuality,
                'class_id': BTTrackClass(tracks[i].classID),
                'position_x_m': tracks[i].f32_positionX_m,
                'position_y_m': tracks[i].f32_positionY_m,
                'velocity_x_mps': tracks[i].f32_velocityX_mps,
                'velocity_y_mps': tracks[i].f32_velocityY_mps,
                'direction_x': tracks[i].f32_directionX,
                'direction_y': tracks[i].f32_directionY
            }
            track_list.append(track)
        
        return ITLResult(result), track_list
    
    def set_ignore_zones(self, ignore_zones: List[dict]) -> ITLResult:
        """Set ignore zones for the tracker
        
        Args:
            ignore_zones: List of ignore zone dictionaries, each containing:
                - active: Boolean indicating if zone is active
                - vertices: List of (x, y) tuples representing vertices
                
        Returns:
            Result code
        """
        nr_of_zones = len(ignore_zones)
        zones_array = (BTIgnoreZone * nr_of_zones)()
        
        for i, zone in enumerate(ignore_zones):
            zones_array[i].b_active = 1 if zone.get('active', False) else 0
            
            vertices = zone.get('vertices', [])
            zones_array[i].ui16_nrOfVertices = len(vertices)
            
            # Initialize min/max with first vertex if available
            if vertices:
                zones_array[i].v2d_min.x = vertices[0][0]
                zones_array[i].v2d_min.y = vertices[0][1]
                zones_array[i].v2d_max.x = vertices[0][0]
                zones_array[i].v2d_max.y = vertices[0][1]
                
                # Add all vertices and update min/max
                for j, (x, y) in enumerate(vertices[:self.BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE]):
                    zones_array[i].v2d_vertex[j].x = x
                    zones_array[i].v2d_vertex[j].y = y
                    
                    # Update min/max
                    zones_array[i].v2d_min.x = min(zones_array[i].v2d_min.x, x)
                    zones_array[i].v2d_min.y = min(zones_array[i].v2d_min.y, y)
                    zones_array[i].v2d_max.x = max(zones_array[i].v2d_max.x, x)
                    zones_array[i].v2d_max.y = max(zones_array[i].v2d_max.y, y)
        
        result = self.lib.itl_set_ignore_zones(zones_array, ctypes.c_uint16(nr_of_zones))
        return ITLResult(result)
    
    def get_ignore_zones(self) -> Tuple[ITLResult, List[dict]]:
        """Get ignore zones from the tracker
        
        Returns:
            Tuple containing:
                - Result code
                - List of ignore zone dictionaries
        """
        zones_array = (BTIgnoreZone * self.BT_MAX_NR_OF_IGNORE_ZONES)()
        
        result = self.lib.itl_get_ignore_zones(zones_array)
        
        ignore_zones = []
        for i in range(self.BT_MAX_NR_OF_IGNORE_ZONES):
            zone = zones_array[i]
            if zone.ui16_nrOfVertices > 0:
                vertices = [(zone.v2d_vertex[j].x, zone.v2d_vertex[j].y) 
                           for j in range(zone.ui16_nrOfVertices)]
                
                ignore_zone = {
                    'active': bool(zone.b_active),
                    'vertices': vertices,
                    'min': (zone.v2d_min.x, zone.v2d_min.y),
                    'max': (zone.v2d_max.x, zone.v2d_max.y)
                }
                ignore_zones.append(ignore_zone)
        
        return ITLResult(result), ignore_zones
    
    def reset_tracks(self) -> ITLResult:
        """Reset all tracks
        
        Returns:
            Result code
        """
        result = self.lib.itl_reset_tracks()
        return ITLResult(result)
    
    def set_installation_height(self, height: float) -> ITLResult:
        """Set installation height
        
        Args:
            height: Installation height in meters
            
        Returns:
            Result code
        """
        result = self.lib.itl_set_installation_height(ctypes.c_float(height))
        return ITLResult(result)
    
    def get_installation_height(self) -> Tuple[ITLResult, float]:
        """Get installation height
        
        Returns:
            Tuple containing:
                - Result code
                - Installation height in meters
        """
        height = ctypes.c_float(0.0)
        result = self.lib.itl_get_installation_height(ctypes.byref(height))
        return ITLResult(result), height.value
    
    def set_installation_angle(self, angle: float) -> ITLResult:
        """Set installation angle
        
        Args:
            angle: Installation angle in degrees
            
        Returns:
            Result code
        """
        result = self.lib.itl_set_installation_angle(ctypes.c_float(angle))
        return ITLResult(result)
    
    def get_installation_angle(self) -> Tuple[ITLResult, float]:
        """Get installation angle
        
        Returns:
            Tuple containing:
                - Result code
                - Installation angle in degrees
        """
        angle = ctypes.c_float(0.0)
        result = self.lib.itl_get_installation_angle(ctypes.byref(angle))
        return ITLResult(result), angle.value
    
    def set_parameter_float(self, parameter_type: BTParameter, value: float) -> ITLResult:
        """Set float parameter
        
        Args:
            parameter_type: Parameter type
            value: Parameter value
            
        Returns:
            Result code
        """
        result = self.lib.itl_set_parameter_f32(ctypes.c_int(parameter_type), ctypes.c_float(value))
        return ITLResult(result)
    
    def set_parameter_uint16(self, parameter_type: BTParameter, value: int) -> ITLResult:
        """Set uint16 parameter
        
        Args:
            parameter_type: Parameter type
            value: Parameter value
            
        Returns:
            Result code
        """
        result = self.lib.itl_set_parameter_ui16(ctypes.c_int(parameter_type), ctypes.c_uint16(value))
        return ITLResult(result)
    
    def set_parameter_int16(self, parameter_type: BTParameter, value: int) -> ITLResult:
        """Set int16 parameter
        
        Args:
            parameter_type: Parameter type
            value: Parameter value
            
        Returns:
            Result code
        """
        result = self.lib.itl_set_parameter_si16(ctypes.c_int(parameter_type), ctypes.c_int16(value))
        return ITLResult(result)
    
    def get_parameter_float(self, parameter_type: BTParameter) -> Tuple[ITLResult, float]:
        """Get float parameter
        
        Args:
            parameter_type: Parameter type
            
        Returns:
            Tuple containing:
                - Result code
                - Parameter value
        """
        value = ctypes.c_float(0.0)
        result = self.lib.itl_get_parameter_f32(ctypes.c_int(parameter_type), ctypes.byref(value))
        return ITLResult(result), value.value
    
    def get_parameter_uint16(self, parameter_type: BTParameter) -> Tuple[ITLResult, int]:
        """Get uint16 parameter
        
        Args:
            parameter_type: Parameter type
            
        Returns:
            Tuple containing:
                - Result code
                - Parameter value
        """
        value = ctypes.c_uint16(0)
        result = self.lib.itl_get_parameter_ui16(ctypes.c_int(parameter_type), ctypes.byref(value))
        return ITLResult(result), value.value
    
    def get_parameter_uint32(self, parameter_type: BTParameter) -> Tuple[ITLResult, int]:
        """Get uint32 parameter
        
        Args:
            parameter_type: Parameter type
            
        Returns:
            Tuple containing:
                - Result code
                - Parameter value
        """
        value = ctypes.c_uint32(0)
        result = self.lib.itl_get_parameter_ui32(ctypes.c_int(parameter_type), ctypes.byref(value))
        return ITLResult(result), value.value
    
    def get_parameter_int16(self, parameter_type: BTParameter) -> Tuple[ITLResult, int]:
        """Get int16 parameter
        
        Args:
            parameter_type: Parameter type
            
        Returns:
            Tuple containing:
                - Result code
                - Parameter value
        """
        value = ctypes.c_int16(0)
        result = self.lib.itl_get_parameter_si16(ctypes.c_int(parameter_type), ctypes.byref(value))
        return ITLResult(result), value.value


# Example usage
if __name__ == "__main__":
    # Create the tracker instance
    tracker = InnoSenTTracker("./libitl.so")
    
    # Initialize the tracker with 50ms cycle time
    result = tracker.init_tracker(0.05)
    print(f"Tracker initialization: {result}")
    
    # Set default values for iSYS-5021
    result = tracker.set_default_values(BTProductCode.BT_PRODUCT_iSYS5021)
    print(f"Set default values: {result}")
    
    # Set installation parameters
    tracker.set_installation_height(2.5)  # 2.5 meters height
    tracker.set_installation_angle(0.0)  # 0 degrees angle (horizontal)
    
    # Example targets (would normally come from radar)
    targets = [
        {
            'rcs_m2': 1.2,
            'range_m': 15.3,
            'velocity_mps': 5.2,
            'angle_azimuth_deg': 10.5
        },
        {
            'rcs_m2': 0.8,
            'range_m': 25.7,
            'velocity_mps': -3.1,
            'angle_azimuth_deg': -5.3
        }
    ]
    
    # Execute tracker with targets
    result = tracker.execute_tracker(targets)
    print(f"Execute tracker: {result}")
    
    # Receive track list
    result, tracks = tracker.receive_track_list()
    print(f"Received {len(tracks)} tracks, result: {result}")
    
    for i, track in enumerate(tracks):
        print(f"Track {i+1}: ID={track['object_id']}, "
              f"Position=({track['position_x_m']:.2f}, {track['position_y_m']:.2f}), "
              f"Velocity=({track['velocity_x_mps']:.2f}, {track['velocity_y_mps']:.2f}), "
              f"Class={track['class_id'].name}")
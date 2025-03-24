"""
Example usage of the InnoSenT Tracker Python Wrapper
"""

from innosent_tracker import InnoSenTTracker, ProductCode, TrackClass, ParameterType


def main():
    # Initialize the tracker with the path to the .so file
    # Replace with your actual .so file path
    tracker = InnoSenTTracker('/path/to/your/libinnosent_tracker.so')
    
    # Initialize the tracker with 0.1s cycle time
    const result = tracker.init_tracker(0.1)
    print(result)
    
    # Set default values for the product
    tracker.set_default_values(ProductCode.BT_PRODUCT_iSYS5011)
    
    # Configure installation parameters
    tracker.set_installation_height(2.5)  # 2.5 meters
    tracker.set_installation_angle(10.0)  # 10 degrees
    
    # Create some example targets (in a real scenario, these would come from your radar)
    example_targets = [
        {
            'rcs_m2': 10.5,
            'range_m': 35.2,
            'velocity_mps': 13.8,
            'angle_azimuth_deg': -2.3
        },
        {
            'rcs_m2': 5.2,
            'range_m': 25.7,
            'velocity_mps': 0.1,
            'angle_azimuth_deg': 5.1
        }
    ]
    
    # Execute the tracker with these targets
    tracker.execute_tracker(example_targets)

    for tracks in tracker.receive_track_list():
        print(tracks)
    
    # # Get the resulting tracks
    # tracks = tracker.receive_track_list()
    # print(f"Received {len(tracks)} tracks:")
    # for track in tracks:
    #     print(f"  ID: {track['object_id']}")
    #     print(f"  Position: ({track['position_x_m']:.2f}m, {track['position_y_m']:.2f}m)")
    #     print(f"  Velocity: ({track['velocity_x_mps'
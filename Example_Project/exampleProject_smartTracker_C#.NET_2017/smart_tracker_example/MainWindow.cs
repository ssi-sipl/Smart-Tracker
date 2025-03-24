using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smart_tracker_example
{
    public partial class MainWindow : Form
    {
        public ethernetAPI_if.ETHResult_t result_eth;
        public IntPtr ethHandle = new System.IntPtr();
        public IntPtr eth_pointer;


        public MainWindow()
        {
            InitializeComponent();
            comboBoxProductCode.Text = "5021";
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            bt_if.ITLResult_t result_bt = bt_if.ITLResult_t.ITL_OK;
            IntPtr bt_pointer;

            float version = 0.0f;
            UInt32 major = 0;
            UInt32 minor = 0;
            UInt32 fix = 0;
            UInt32 version_date = 0;
            UInt16 compilation_date_len = 0;
            string compilation_date = "";

            if (buttonConnect.Text == "Connect")
            {
                buttonConnect.Enabled = false;

                /* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */
                /* Ethernet Connection to iSYS-5020 */
                /* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */
                result_eth = ethernetAPI_if.ETH_getApiVersion(ref version);                                                                             //get ethernetAPI version
                if (result_eth != ethernetAPI_if.ETHResult_t.ETH_ERR_OK) {
                    //ERROR
                    MessageBox.Show("Error: ETH_getApiVersion", "Error", MessageBoxButtons.OK);
                }

                result_eth = ethernetAPI_if.ETH_initSystem(ref ethHandle, (byte)numericUpIp1.Value, (byte)numericUpIp2.Value, (byte)numericUpIp3.Value, (byte)numericUpIp4.Value, 2050);        //connect to sensor ip address with default port 2050
                if (result_eth != ethernetAPI_if.ETHResult_t.ETH_ERR_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: ETH_initSystem", "Error", MessageBoxButtons.OK);
                }

                /* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */
                /* Smart Tracker Init */
                /* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */

                result_bt = bt_if.itl_init_tracker(0.1f);                                                                                   // Init Tracker with default cycletime (100ms)
                if (result_bt != bt_if.ITLResult_t.ITL_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: itl_init_tracker", "Error", MessageBoxButtons.OK);
                }

                result_bt = bt_if.itl_get_parameter_ui32(bt_if.bt_parameter_enum_t.BT_PARAMETER_UI32_VERSION_MAJOR, ref major);             //get major version number
                if (result_bt != bt_if.ITLResult_t.ITL_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: itl_get_parameter_ui32", "Error", MessageBoxButtons.OK);
                }

                result_bt = bt_if.itl_get_parameter_ui32(bt_if.bt_parameter_enum_t.BT_PARAMETER_UI32_VERSION_MINOR, ref minor);             //get minor version number
                if (result_bt != bt_if.ITLResult_t.ITL_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: itl_get_parameter_ui32", "Error", MessageBoxButtons.OK);
                }

                result_bt = bt_if.itl_get_parameter_ui32(bt_if.bt_parameter_enum_t.BT_PARAMETER_UI32_VERSION_FIXED, ref fix);               //get fix version number
                if (result_bt != bt_if.ITLResult_t.ITL_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: itl_get_parameter_ui32", "Error", MessageBoxButtons.OK);
                }

                result_bt = bt_if.itl_get_parameter_ui32(bt_if.bt_parameter_enum_t.BT_PARAMETER_UI32_VERSION_DATE, ref version_date);       //get version date
                if (result_bt != bt_if.ITLResult_t.ITL_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: itl_get_parameter_ui32", "Error", MessageBoxButtons.OK);
                }

                bt_pointer = Marshal.AllocHGlobal(256);                                                                                     //allocate memory to Pointer
                result_bt = bt_if.itl_get_compilation_date(bt_pointer, ref compilation_date_len);                                           //get compilation date
                if (result_bt != bt_if.ITLResult_t.ITL_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: itl_get_compilation_date", "Error", MessageBoxButtons.OK);
                }
                compilation_date = Marshal.PtrToStringAnsi(bt_pointer);                                                                     //copy pointer data to string
                Marshal.FreeHGlobal(bt_pointer);                                                                                            //free allocated memory

                /* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */
                /* set iSYS-5021 default parameter */
                /* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */

                if (comboBoxProductCode.Text == "5011") {
                    result_bt = bt_if.itl_set_default_values(bt_if.ITLProductCode_t.ITL_PRODUCT_iSYS5011);
                    if (result_bt != bt_if.ITLResult_t.ITL_OK)
                    {
                        //ERROR
                        MessageBox.Show("Error: itl_set_default_values", "Error", MessageBoxButtons.OK);
                    }
                }

                if (comboBoxProductCode.Text == "5021") {

                    result_bt = bt_if.itl_set_default_values(bt_if.ITLProductCode_t.ITL_PRODUCT_iSYS5021);
                    if (result_bt != bt_if.ITLResult_t.ITL_OK)
                    {
                        //ERROR
                        MessageBox.Show("Error: itl_set_default_values", "Error", MessageBoxButtons.OK);
                    }
                }

                labelEthernetAPIversionValue.Text = version.ToString();
                labelSmartTrackerVersionValue.Text = major.ToString() + "." + minor.ToString("D" + fix.ToString());
                labelSmartTrackerVersionDateValue.Text = version_date.ToString();
                labelSmartTrackerCompiliationDateValue.Text = compilation_date.Substring(0, compilation_date_len);

                buttonConnect.Text = "Disconnect";
                buttonConnect.Enabled = true;
                buttonRun.Enabled = true;
                buttonResetTracks.Enabled = true;
                chartPlot.Series[2].Points.Clear();                                                                     //clear IgnoreZone plot
                buttonIgnoreZoneExample.Text = "Set example Ignore Zone";
                buttonIgnoreZoneExample.Enabled = true;
                checkBoxWindFilter.Enabled = true;
                buttonInstallationHeight.Enabled = true;
                buttonInstallationAngle.Enabled = true;
                numericUpDownInstallationHeight.Enabled = true;
                numericUpDownInstallationAngle.Enabled = true;
            }
            else {
                buttonConnect.Enabled = false;

                result_eth = ethernetAPI_if.ETH_exitSystem(ethHandle);                                                                      //disconnect from sensor
                if (result_eth != ethernetAPI_if.ETHResult_t.ETH_ERR_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: ETH_exitSystem", "Error", MessageBoxButtons.OK);
                }

                labelEthernetAPIversionValue.Text = "-";
                labelSmartTrackerVersionValue.Text = "-";
                labelSmartTrackerVersionDateValue.Text = "-";
                labelSmartTrackerCompiliationDateValue.Text = "-";

                buttonConnect.Text = "Connect";
                buttonConnect.Enabled = true;
                buttonRun.Enabled = false;
                buttonResetTracks.Enabled = false;
                buttonIgnoreZoneExample.Enabled = false;
                checkBoxWindFilter.Enabled = false;
                buttonInstallationHeight.Enabled = false;
                buttonInstallationAngle.Enabled = false;
                numericUpDownInstallationHeight.Enabled = false;
                numericUpDownInstallationAngle.Enabled = false;
            }
        }

        private void dataTimer_Tick(object sender, EventArgs e)
        {
            bt_if.ITLResult_t result_bt = bt_if.ITLResult_t.ITL_OK;
            IntPtr bt_pointer;
            UInt16 NrOfTracks = 0;
            ethernetAPI_if.ETHTargetList_t ETH_TargetList = new ethernetAPI_if.ETHTargetList_t();                                                   //Create new ethernetAPI TargetList
            bt_if.bt_target_list_array_t BT_TargetList = new bt_if.bt_target_list_array_t();                                                        //Create new array of smart tracker TargetList
            BT_TargetList.TargetList = new bt_if.bt_target_list_rv_t[bt_if.BT_MAX_NR_OF_TARGETS];                                                   //Allocate 256 Targets in smart tracker TargetList

            if (checkBoxHoldPlotTargets.Checked == false) {
                chartPlot.Series[0].Points.Clear();
            }

            if (checkBoxHoldPlotTracks.Checked == false) {
                chartPlot.Series[1].Points.Clear();
            }

            eth_pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ethernetAPI_if.ETHTargetList_t)));                                                 //allocate memory to Pointer
            result_eth = ethernetAPI_if.ETH_getTargetList(ethHandle, eth_pointer);                                                                      //get TargetList from ethernetAPI to pointer
            if (result_eth != ethernetAPI_if.ETHResult_t.ETH_ERR_OK)
            {
                dataTimer.Enabled = false;
                buttonRun.Enabled = true;
                //ERROR
                MessageBox.Show("Error: ETH_getTargetList", "Error", MessageBoxButtons.OK);
                return;
            }
            ETH_TargetList = (ethernetAPI_if.ETHTargetList_t)Marshal.PtrToStructure(eth_pointer, typeof(ethernetAPI_if.ETHTargetList_t));               //copy pointer data to structure
            Marshal.FreeHGlobal(eth_pointer);                                                                                                           //free allocated memory

            toolStripStatusLabelFrameID.Text = "FrameID: " + ETH_TargetList.frameID;

            for (int i = 0; i < ETH_TargetList.nrOfTargets; i++) {                                                                                      //convert ethernetAPI TargetList to smart tracker TargetList
                BT_TargetList.TargetList[i].f32_angleAzimuth_deg = ETH_TargetList.targetList[i].angleAzimuth;
                BT_TargetList.TargetList[i].f32_range_m = ETH_TargetList.targetList[i].range;
                BT_TargetList.TargetList[i].f32_reserved1 = ETH_TargetList.targetList[i].reserved1;
                BT_TargetList.TargetList[i].f32_reserved2 = ETH_TargetList.targetList[i].reserved2;
                BT_TargetList.TargetList[i].f32_rcs_m2 = ETH_TargetList.targetList[i].signalStrength;
                BT_TargetList.TargetList[i].f32_velocity_mps = ETH_TargetList.targetList[i].velocity;


                if (checkBoxShowTargets.Checked == true)
                {
                    double cDistanceX = 0.0;
                    double cDistanceY = 0.0;

                    cDistanceX = Math.Sin((BT_TargetList.TargetList[i].f32_angleAzimuth_deg / 180.0 * bt_if.PI_I)) * -BT_TargetList.TargetList[i].f32_range_m;      //calculate X in meter
                    cDistanceY = Math.Cos((BT_TargetList.TargetList[i].f32_angleAzimuth_deg / 180.0 * bt_if.PI_I)) * BT_TargetList.TargetList[i].f32_range_m;       //calculate Y in meter
                    chartPlot.Series[0].Points.AddXY(cDistanceX, cDistanceY);                                                                                       //add point to plot
                }
                else {
                    chartPlot.Series[0].Points.AddXY(0, -100);                                                                                                      //add dummy point to show plot grid
                }
            }

            if (ETH_TargetList.nrOfTargets == 0) {
                chartPlot.Series[0].Points.AddXY(0, -100);                                                                                      //add dummy point to show plot grid
            }

            bt_pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bt_if.bt_target_list_array_t)));                                            //allocate memory to Pointer
            Marshal.StructureToPtr(BT_TargetList, bt_pointer, false);                                                                           //set pointer to structure
            result_bt = bt_if.itl_execute_tracker(bt_pointer, ETH_TargetList.nrOfTargets);                                                      //put TargetList into smart tracker
            if (result_bt != bt_if.ITLResult_t.ITL_OK)
            {
                dataTimer.Enabled = false;
                buttonRun.Enabled = true;
                //ERROR
                MessageBox.Show("Error: itl_execute_tracker", "Error", MessageBoxButtons.OK);
                return;
            }
            Marshal.FreeHGlobal(bt_pointer);                                                                                                    //free allocated memory

            bt_if.bt_ext_track_list_array_t BT_TrackList = new bt_if.bt_ext_track_list_array_t();                                               //create new smart tracker TrackList
            BT_TrackList.TrackList = new bt_if.bt_ext_track_list_t[bt_if.BT_MAX_NR_OF_TRACKS];                                                  //Allocate 64 tracks in smart tracker TrackList

            bt_pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bt_if.bt_ext_track_list_array_t)));                                         //allocate memory to Pointer        
            result_bt = bt_if.itl_receive_track_list(bt_pointer, ref NrOfTracks);                                                               //get smart tracker Tracklist to pointer
            BT_TrackList = (bt_if.bt_ext_track_list_array_t)Marshal.PtrToStructure(bt_pointer, typeof(bt_if.bt_ext_track_list_array_t));        //copy pointer data to structure
            Marshal.FreeHGlobal(bt_pointer);                                                                                                    //free allocated memory

            /* PLOT TRACKS */
            if (checkBoxShowTracks.Checked == true)
            {
                for (int i = 0; i < NrOfTracks; i++)                                                                                            //run through all available tracks
                {
                    chartPlot.Series[1].Points.AddXY(BT_TrackList.TrackList[i].f32_positionX_m, BT_TrackList.TrackList[i].f32_positionY_m);     //add point to plot
                }

            }
            else {
                chartPlot.Series[1].Points.AddXY(0, -100);                                                                                      //add dummy point to show plot grid */
            }

        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (buttonRun.Text == "Run")
            {
                toolStripStatusLabelStatus.Text = "Status: running...";
                dataTimer.Interval = (int)numericUpDownTimerInterval.Value;                                                                     //set timer interval
                dataTimer.Enabled = true;                                                                                                       //enable timer
                buttonRun.Text = "Stop";
                buttonConnect.Enabled = false;
                numericUpDownTimerInterval.Enabled = false;
            }
            else {
                toolStripStatusLabelStatus.Text = "Status: stopped";
                dataTimer.Enabled = false;
                buttonRun.Text = "Run";
                buttonConnect.Enabled = true;                                                                                                   //disable timer
                numericUpDownTimerInterval.Enabled = true;
            }
        }

        private void MainWindow_Closing(object sender, FormClosingEventArgs e)
        {
            dataTimer.Enabled = false;
            result_eth = ethernetAPI_if.ETH_exitSystem(ethHandle);                                                                      //disconnect from sensor
            Environment.Exit(0);
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            chartPlot.Series[0].Points.AddXY(0, -100);                              //add dummy point to show plot grid
        }

        private void buttonResetTracks_Click(object sender, EventArgs e)
        {
            bt_if.ITLResult_t result_bt;

            result_bt = bt_if.itl_reset_tracks();                                   //delete all existing tracks in smart tracker
            if (result_bt != bt_if.ITLResult_t.ITL_OK)
            {
                //ERROR
                MessageBox.Show("Error: itl_reset_tracks", "Error", MessageBoxButtons.OK);
            }
        }

        private void buttonIgnoreZoneExample_Click(object sender, EventArgs e)
        {
            IntPtr bt_pointer;
            bt_if.ITLResult_t result_bt = bt_if.ITLResult_t.ITL_OK;

            /* A Ignore Zone needs minimum 4 v2d_vertex Points and could have maximum 10 v2d_vertex Points */

            bt_if.bt_ignore_zone_array_t BT_IgnoreZone = new bt_if.bt_ignore_zone_array_t();                                //Create new smart tracker IgnoreZone
            BT_IgnoreZone.IgnoreZone = new bt_if.bt_ignore_zone_t[bt_if.BT_MAX_NR_OF_IGNORE_ZONES];                         //Create new array of smart tracker IgnoreZone
            BT_IgnoreZone.IgnoreZone[0].v2d_vertex = new bt_if.v2d_f32_it[bt_if.BT_MAX_NR_OF_POINTS_PER_IGNORE_ZONE];       //Allocate 10 Ignore Zones in smart tracker IgnoreZone

            if (buttonIgnoreZoneExample.Text == "Set example Ignore Zone")
            {
                /* define example ignore zone */
                BT_IgnoreZone.IgnoreZone[0].b_active = 1;
                BT_IgnoreZone.IgnoreZone[0].ui16_nrOfVertices = 4;
                BT_IgnoreZone.IgnoreZone[0].v2d_vertex[0].x = 10.0f;
                BT_IgnoreZone.IgnoreZone[0].v2d_vertex[0].y = 10.0f;
                BT_IgnoreZone.IgnoreZone[0].v2d_vertex[1].x = 90.0f;
                BT_IgnoreZone.IgnoreZone[0].v2d_vertex[1].y = 10.0f;
                BT_IgnoreZone.IgnoreZone[0].v2d_vertex[2].x = 90.0f;
                BT_IgnoreZone.IgnoreZone[0].v2d_vertex[2].y = 140.0f;
                BT_IgnoreZone.IgnoreZone[0].v2d_vertex[3].x = 10.0f;
                BT_IgnoreZone.IgnoreZone[0].v2d_vertex[3].y = 140.0f;

                bt_pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bt_if.bt_ignore_zone_array_t)));                    //allocate memory to Pointer
                Marshal.StructureToPtr(BT_IgnoreZone, bt_pointer, false);                                                   //set pointer to structure
                result_bt = bt_if.itl_set_ignore_zones(bt_pointer, 1);                                                      //set ignore zones
                Marshal.FreeHGlobal(bt_pointer);                                                                            //free allocated memory
                if (result_bt != bt_if.ITLResult_t.ITL_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: itl_set_ignore_zones", "Error", MessageBoxButtons.OK);
                }

                buttonIgnoreZoneExample.Text = "Remove example Ignore Zone";

                //Plot example ignore zone
                chartPlot.Series[2].Points.AddXY(10, 10);
                chartPlot.Series[2].Points.AddXY(90, 10);
                chartPlot.Series[2].Points.AddXY(90, 140);
                chartPlot.Series[2].Points.AddXY(10, 140);
                chartPlot.Series[2].Points.AddXY(10, 10);
            }
            else {
                BT_IgnoreZone.IgnoreZone[0].b_active = 0;                                                               //set ignore zone inactive

                bt_pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bt_if.bt_ignore_zone_array_t)));                //allocate memory to Pointer
                Marshal.StructureToPtr(BT_IgnoreZone, bt_pointer, false);                                               //set structure to pointer
                result_bt = bt_if.itl_set_ignore_zones(bt_pointer, 1);                                                  //set ignore zones
                Marshal.FreeHGlobal(bt_pointer);                                                                        //free allocated memory
                if (result_bt != bt_if.ITLResult_t.ITL_OK)
                {
                    //ERROR
                    MessageBox.Show("Error: itl_set_ignore_zones", "Error", MessageBoxButtons.OK);
                }

                buttonIgnoreZoneExample.Text = "Set example Ignore Zone";
                chartPlot.Series[2].Points.Clear();
            }

            /* example for read Ignore Zones */
            bt_if.bt_ignore_zone_array_t ReadZones = new bt_if.bt_ignore_zone_array_t();
            bt_pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bt_if.bt_ignore_zone_array_t)));                                //allocate memory to Pointer
            result_bt = bt_if.itl_get_ignore_zones(bt_pointer);                                                                     //get ignore zones to pointer
            if (result_bt != bt_if.ITLResult_t.ITL_OK)
            {
                //ERROR
                MessageBox.Show("Error: itl_get_ignore_zones", "Error", MessageBoxButtons.OK);
            }
            ReadZones = (bt_if.bt_ignore_zone_array_t)Marshal.PtrToStructure(bt_pointer, typeof(bt_if.bt_ignore_zone_array_t));     //copy pointer data to structure
            Marshal.FreeHGlobal(bt_pointer);

        }

        private void checkBoxWindFilter_CheckedChanged(object sender, EventArgs e)
        {
            bt_if.ITLResult_t result_bt = bt_if.ITLResult_t.ITL_OK;

            if (checkBoxWindFilter.Checked == true) {
                result_bt = bt_if.itl_set_parameter_ui16(bt_if.bt_parameter_enum_t.BT_PARAMETER_UI16_WIND_FILTER_ACTIVE, 1);                                   //set wind filter
            }
            else {
                result_bt = bt_if.itl_set_parameter_ui16(bt_if.bt_parameter_enum_t.BT_PARAMETER_UI16_WIND_FILTER_ACTIVE, 0);                                   //set wind filter
            }

            if (result_bt != bt_if.ITLResult_t.ITL_OK)
            {
                //ERROR
                MessageBox.Show("Error: itl_set_parameter_ui16 BT_PARAMETER_UI16_WIND_FILTER_ACTIVE", "Error", MessageBoxButtons.OK);
            }
        }

        private void buttonInstallationHeight_Click(object sender, EventArgs e)
        {
            bt_if.ITLResult_t result_bt = bt_if.ITLResult_t.ITL_OK;

            float installationHeight = 0.0f;
            installationHeight = (float)numericUpDownInstallationHeight.Value;                                                                      //convert installation height

            result_bt = bt_if.itl_set_installation_height(installationHeight);                                                                      //change installationHeight parameter
            if (result_bt != bt_if.ITLResult_t.ITL_OK)
            {
                //ERROR
                MessageBox.Show("Error: itl_set_installation_height", "Error", MessageBoxButtons.OK);
            }
        }

        private void buttonInstallationAngle_Click(object sender, EventArgs e)
        {
            bt_if.ITLResult_t result_bt = bt_if.ITLResult_t.ITL_OK;

            float installationAngle = 0.0f;
            installationAngle = (float)numericUpDownInstallationAngle.Value;                                                                     //convert installation height

            result_bt = bt_if.itl_set_installation_angle(installationAngle);                                                                     //change installationAngle parameter
            if (result_bt != bt_if.ITLResult_t.ITL_OK)
            {
                //ERROR
                MessageBox.Show("Error: itl_set_installation_angle", "Error", MessageBoxButtons.OK);
            }

        }

    }
}

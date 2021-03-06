namespace Bedtime_Countdown_Timer
{
    using Windows.UI.Notifications;
    using Microsoft.Toolkit.Uwp.Notifications;

    enum Notification : int
    {
        Test,
        Start,
        One_hour,
        Thirty_min,
        Time_up
    }

    public partial class Form_Main : Form
    {

        public static DateTime time_now_datetime = DateTime.Now;
        public static TimeOnly time_now_timeonly = new TimeOnly(00, 00, 00);

        public static DateTime time_bedtime_datetime = DateTime.Now;
        public static TimeOnly time_bedtime_timeonly = new TimeOnly(00, 00, 00);

        public static TimeOnly time_duration_timeonly = new TimeOnly(00, 00, 00);

        public static TimeOnly time_wake_up_timeonly = new TimeOnly(00, 00, 00);

        public static TimeSpan time_remaining_timespan = new TimeSpan(00, 00, 00);
        public static TimeOnly time_remaining_timeonly = new TimeOnly(00, 00, 00);

        public static TimeOnly time_const_zero_timeonly = new TimeOnly(00, 00, 00);
        public static TimeOnly time_const_one_sec_timeonly = new TimeOnly(00, 00, 01);
        public static TimeOnly time_const_thirty_min_timeonly = new TimeOnly(00, 30, 00);
        public static TimeOnly time_const_one_hour_timeonly = new TimeOnly(01, 00, 00);
        public static TimeSpan time_const_24_hr_timespan = new TimeSpan(24, 00, 00);

        public static string time_formats_timeonly = "r";

        //public static double time_remaining_ratio = 1;

        public static bool flag_text_change_textbox_bedtime = false;
        public static bool flag_text_change_textbox_duration = false;
        public static bool flag_text_change_textbox_wake_up = false;

        public static bool flag_timer_trigger_enable = true;

        public static bool flag_thirty_min_remaining = false;
        public static bool flag_one_hour_remaining = false;
        public static bool flag_time_up = false;
        

        OperatingSystem os_version = System.Environment.OSVersion;

        public Form_Main()
        {
            InitializeComponent();

            button_pause.Text = "Pause";

            textbox_bedtime.Text = Properties.Settings.Default.user_setting_time_bedtime;
            textbox_duration.Text = Properties.Settings.Default.user_setting_time_duration;



            Initialize();

            /*
            //Notification Test
            if (os_version.Version.Major >= 10)
            {
                Toast_Notification(NOTIFICATION_TEST);
            }
            */

        }

        private void timer_trigger_Tick(object sender, EventArgs e)
        {
            if (flag_timer_trigger_enable == true)
            {
                time_now_datetime = DateTime.Now;
                time_now_datetime = new DateTime(time_now_datetime.Year, time_now_datetime.Month, time_now_datetime.Day, time_now_datetime.Hour, time_now_datetime.Minute, time_now_datetime.Second);
                time_now_timeonly = TimeOnly.FromDateTime(time_now_datetime);
                textbox_time_now.Text = time_now_timeonly.ToString(time_formats_timeonly);

                TimeOnly.TryParse(textbox_bedtime.Text, out time_bedtime_timeonly);

                if (time_bedtime_timeonly >= time_now_timeonly)
                {
                    time_remaining_timespan = time_bedtime_timeonly - time_now_timeonly;
                }
                else
                {
                    time_bedtime_datetime = time_now_datetime - time_now_datetime.TimeOfDay;
                    time_bedtime_datetime = time_bedtime_datetime + time_bedtime_timeonly.ToTimeSpan();
                    time_bedtime_datetime = time_bedtime_datetime.AddDays(1);

                    time_remaining_timespan = time_bedtime_datetime - time_now_datetime;
                }

                time_remaining_timeonly = TimeOnly.FromTimeSpan(time_remaining_timespan);
                textbox_remaining_time.Text = time_remaining_timeonly.ToString(time_formats_timeonly);

                /*
                time_remaining_ratio = time_remaining_timeonly.ToTimeSpan().TotalMinutes / time_const_30min_timeonly.ToTimeSpan().TotalMinutes;
                if (time_remaining_ratio > 1 || time_remaining_ratio < 0)
                {
                    time_remaining_ratio = 1;
                }
                */

                if ((flag_one_hour_remaining == false) && (time_remaining_timeonly == time_const_one_hour_timeonly))
                {
                    flag_one_hour_remaining = true;
                    if (checkbox_remind.Checked == true)
                    {
                        if (os_version.Version.Major >= 10)
                        {
                            Toast_Notification(Notification.One_hour);
                        }
                        else
                        {
                            MessageBox.Show("1 hour remaining!!");
                        }
                    }
                }
                else if ((flag_one_hour_remaining == true) && (time_remaining_timeonly <= TimeOnly.FromTimeSpan(time_const_one_hour_timeonly - time_const_one_sec_timeonly)))
                {
                    flag_one_hour_remaining = false;
                }



                if ((flag_thirty_min_remaining == false) && (time_remaining_timeonly == time_const_thirty_min_timeonly))
                {
                    flag_thirty_min_remaining = true;
                    if (checkbox_remind.Checked == true)
                    {
                        if (os_version.Version.Major >= 10)
                        {
                            Toast_Notification(Notification.Thirty_min);
                        }
                        else
                        {
                            MessageBox.Show("30 minutes remaining!!");
                        }
                    }
                }
                else if ((flag_thirty_min_remaining == true) && (time_remaining_timeonly <= TimeOnly.FromTimeSpan(time_const_thirty_min_timeonly - time_const_one_sec_timeonly)))
                {
                    flag_thirty_min_remaining = false;
                }


                if ((flag_time_up == false) && (time_remaining_timeonly == time_const_zero_timeonly))
                {
                    flag_time_up = true;

                    if (checkbox_remind.Checked == true)
                    {
                        if (os_version.Version.Major >= 10)
                        {
                            Toast_Notification(Notification.Time_up);
                        }
                        else
                        {
                            MessageBox.Show("Time's up!!");
                        }
                    }
                }
                else if ((flag_time_up == true) && (time_remaining_timeonly >= time_const_one_sec_timeonly))
                {
                    flag_time_up = false;
                }
            }
        }

        private void textbox_time_now_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_bedtime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_duration_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_wake_up_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_bedtime_Leave(object sender, EventArgs e)
        {
            TimeOnly.TryParse(textbox_bedtime.Text, out time_bedtime_timeonly);
            TimeOnly.TryParse(textbox_duration.Text, out time_duration_timeonly);

            if (time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan() >= time_const_24_hr_timespan)
            {
                time_wake_up_timeonly = TimeOnly.FromTimeSpan(time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan() - time_const_24_hr_timespan);
            }
            else
            {
                time_wake_up_timeonly = TimeOnly.FromTimeSpan(time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan());
            }

            textbox_wake_up.Text = time_wake_up_timeonly.ToString(time_formats_timeonly);
            User_Property_Save();
        }

        private void textbox_duration_Leave(object sender, EventArgs e)
        {

            TimeOnly.TryParse(textbox_bedtime.Text, out time_bedtime_timeonly);
            TimeOnly.TryParse(textbox_duration.Text, out time_duration_timeonly);

            if (time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan() >= time_const_24_hr_timespan)
            {
                time_wake_up_timeonly = TimeOnly.FromTimeSpan(time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan() - time_const_24_hr_timespan);
            }
            else
            {
                time_wake_up_timeonly = TimeOnly.FromTimeSpan(time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan());
            }

            textbox_wake_up.Text = time_wake_up_timeonly.ToString(time_formats_timeonly);
            User_Property_Save();
        }

        private void textbox_wake_up_Leave(object sender, EventArgs e)
        {
            TimeOnly.TryParse(textbox_duration.Text, out time_duration_timeonly);
            TimeOnly.TryParse(textbox_wake_up.Text, out time_wake_up_timeonly);

            if (time_wake_up_timeonly >= time_duration_timeonly)
            {
                time_bedtime_timeonly = TimeOnly.FromTimeSpan(time_wake_up_timeonly.ToTimeSpan() - time_duration_timeonly.ToTimeSpan());
            }
            else
            {
                time_bedtime_timeonly = TimeOnly.FromTimeSpan(time_wake_up_timeonly.ToTimeSpan() - time_duration_timeonly.ToTimeSpan() + time_const_24_hr_timespan);
            }

            textbox_bedtime.Text = time_bedtime_timeonly.ToString(time_formats_timeonly);
            User_Property_Save();
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            button_pause.Focus();
            Timer_Control();

            if (flag_timer_trigger_enable == true)
            {
                if (os_version.Version.Major >= 10)
                {
                    Toast_Notification(Notification.Start);
                }
            }
            else
            {
                ToastNotificationManagerCompat.History.Clear();
            }
        }

        private void Timer_Control()
        {
            if (flag_timer_trigger_enable == true)
            {
                flag_timer_trigger_enable = false;
                button_pause.Text = "Start";

                textbox_bedtime.ReadOnly = false;
                textbox_duration.ReadOnly = false;
                textbox_wake_up.ReadOnly = false;
            }
            else
            {
                flag_timer_trigger_enable = true;
                button_pause.Text = "Pause";

                Initialize();

                User_Property_Save();
            }
        }

        private void User_Property_Save()
        {
            Properties.Settings.Default.user_setting_time_bedtime = textbox_bedtime.Text;
            Properties.Settings.Default.user_setting_time_duration = textbox_duration.Text;
            Properties.Settings.Default.Save();
        }

        private void checkbox_remind_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textbox_remaining_time_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form_Main_Load(object sender, EventArgs e)
        {

        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_pause.Focus();
                Timer_Control();
            }
        }

        private void Form_Main_Click(object sender, EventArgs e)
        {
            button_pause.Focus();
        }

        private void Toast_Notification(Notification notification_type)
        {
            int conversationId = 384928;

            ToastNotificationManagerCompat.History.Clear();

            switch (notification_type)
            {
                case Notification.Test:
                    new ToastContentBuilder()
                        .AddArgument("conversationId", conversationId)
                        //.AddText("OS Version: " + os_version.ToString())
                        .AddText("Platform: " + os_version.Platform.ToString())
                        .AddText("Version: " + os_version.Version.ToString())
                        .AddText("Version(Major): " + os_version.Version.Major.ToString())

                        .Show();
                    break;
                case Notification.Start:
                    new ToastContentBuilder()
                        .AddArgument("conversationId", conversationId)
                        .AddText("Start")
                        .AddText("OS Version: " + os_version.ToString())
                        .AddText("Version(Major): " + os_version.Version.Major.ToString())

                        .Show();
                    break;
                
                case Notification.One_hour:
                    new ToastContentBuilder()
                        .AddArgument("conversationId", conversationId)
                        .AddText("1 hour remaining!!")

                        .AddButton(new ToastButton()
                        .SetContent("Dismiss")
                        )

                        .SetToastScenario(ToastScenario.Reminder)

                        .Show();
                    break;

                case Notification.Thirty_min:
                    new ToastContentBuilder()
                        .AddArgument("conversationId", conversationId)
                        .AddText("30 minutes remaining!!")

                        .AddButton(new ToastButton()
                        .SetContent("Dismiss")
                        )

                        .SetToastScenario(ToastScenario.Reminder)

                        .Show();
                    break;

                case Notification.Time_up:
                    new ToastContentBuilder()
                        .AddArgument("conversationId", conversationId)
                        .AddText("Time's up!!")

                        .AddButton(new ToastButton()
                        .SetContent("Dismiss"))

                        .SetToastScenario(ToastScenario.Alarm)

                        .Show();


                    break;

                default:
                    break;
            }
        }


        private void Initialize()
        {
            textbox_bedtime.ReadOnly = true;
            textbox_duration.ReadOnly = true;
            textbox_wake_up.ReadOnly = true;

            TimeOnly.TryParse(textbox_bedtime.Text, out time_bedtime_timeonly);
            TimeOnly.TryParse(textbox_duration.Text, out time_duration_timeonly);

            time_wake_up_timeonly = TimeOnly.FromTimeSpan(time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan());

            textbox_wake_up.Text = time_wake_up_timeonly.ToString(time_formats_timeonly);

            flag_time_up = false;
            flag_thirty_min_remaining = false;
            flag_one_hour_remaining = false;
        }
    }
}
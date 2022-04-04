namespace Bedtime_Countdown_Timer
{
    public partial class Form_Main : Form
    {
        public const int NOTIFICATION_START = 1;
        public const int NOTIFICATION_30MIN = 2;
        public const int NOTIFICATION_TIME_UP = 3;

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
        public static TimeOnly time_const_30min_timeonly = new TimeOnly(00, 30, 00);
        public static TimeSpan time_const_24_hr_timespan = new TimeSpan(24, 00, 00);

        public static string time_formats_timeonly = "r";

        public static bool flag_text_change_textbox_bedtime = false;
        public static bool flag_text_change_textbox_duration = false;
        public static bool flag_text_change_textbox_wake_up = false;

        public static bool flag_timer_trigger_enable = true;

        public static bool flag_time_up = false;
        public static bool flag_30min_remaining = false;

        public Form_Main()
        {
            InitializeComponent();


            button_pause.Text = "Pause";

            textbox_bedtime.Text = Properties.Settings.Default.user_setting_time_bedtime;
            textbox_duration.Text = Properties.Settings.Default.user_setting_time_duration;

            TimeOnly.TryParse(textbox_bedtime.Text, out time_bedtime_timeonly);
            TimeOnly.TryParse(textbox_duration.Text, out time_duration_timeonly);

            time_wake_up_timeonly = TimeOnly.FromTimeSpan(time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan());
            
            textbox_wake_up.Text = time_wake_up_timeonly.ToString(time_formats_timeonly);
            
            flag_time_up = false;
            flag_30min_remaining = false;

            textbox_bedtime.ReadOnly = true;
            textbox_duration.ReadOnly = true;
            textbox_wake_up.ReadOnly = true;

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


                if ((flag_30min_remaining == false) && (time_remaining_timeonly == time_const_30min_timeonly))
                {
                    flag_30min_remaining = true;
                    if (checkbox_remind.Checked == true)
                    {
                        //MessageBox.Show("30 minutes remaining!!");
                        Toast_Notification(NOTIFICATION_30MIN);
                    }
                }
                else if ((flag_30min_remaining == true) && (time_remaining_timeonly <= TimeOnly.FromTimeSpan(time_const_30min_timeonly - time_const_one_sec_timeonly)))
                {
                    flag_30min_remaining = false;
                }

                
                if ((flag_time_up == false) && (time_remaining_timeonly == time_const_zero_timeonly))
                {
                    flag_time_up = true;

                    if (checkbox_remind.Checked == true)
                    {
                        MessageBox.Show("Time's up!!");
                        Toast_Notification(NOTIFICATION_TIME_UP);


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

            if(time_bedtime_timeonly.ToTimeSpan() + time_duration_timeonly.ToTimeSpan() >= time_const_24_hr_timespan)
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
                Toast_Notification(NOTIFICATION_START);
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

                textbox_bedtime.ReadOnly = true;
                textbox_duration.ReadOnly = true;
                textbox_wake_up.ReadOnly = true;

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

        private void Toast_Notification(int notification_type)
        {
            int conversationId = 384928;


            switch (notification_type)
            {
                case NOTIFICATION_START:
                    new Microsoft.Toolkit.Uwp.Notifications.ToastContentBuilder()
                        .AddArgument("conversationId", conversationId)
                        .AddText("Bedtime Countdown Timer")
                        .AddText("Start")

                        .Show();
                    break;

                case NOTIFICATION_30MIN:
                    new Microsoft.Toolkit.Uwp.Notifications.ToastContentBuilder()
                        .AddArgument("conversationId", conversationId)
                        .AddText("Bedtime Countdown Timer")
                        .AddText("30 minutes remaining!!")

                        .AddButton(new Microsoft.Toolkit.Uwp.Notifications.ToastButton()
                        .SetContent("Dismiss")
                        .AddArgument("action", "reply")
                        .SetBackgroundActivation())

                        .SetToastScenario(Microsoft.Toolkit.Uwp.Notifications.ToastScenario.Reminder)

                        .Show();
                    break;

                case NOTIFICATION_TIME_UP:
                    new Microsoft.Toolkit.Uwp.Notifications.ToastContentBuilder()
                    .AddArgument("conversationId", conversationId)
                    .AddText("Bedtime Countdown Timer")
                    .AddText("Time's up!!")

                    .AddButton(new Microsoft.Toolkit.Uwp.Notifications.ToastButton()
                    .SetContent("Dismiss")
                    .AddArgument("action", "reply")
                    .SetBackgroundActivation())

                    .SetToastScenario(Microsoft.Toolkit.Uwp.Notifications.ToastScenario.Alarm)

                    .Show();


                    break;

                default:
                break;
            }




        }



    }
}
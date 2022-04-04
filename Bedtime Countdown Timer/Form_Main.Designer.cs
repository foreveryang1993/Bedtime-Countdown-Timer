namespace Bedtime_Countdown_Timer
{
    partial class Form_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_pause = new System.Windows.Forms.Button();
            this.textbox_time_now = new System.Windows.Forms.TextBox();
            this.timer_trigger = new System.Windows.Forms.Timer(this.components);
            this.label_now = new System.Windows.Forms.Label();
            this.label_bedtime = new System.Windows.Forms.Label();
            this.label_duration = new System.Windows.Forms.Label();
            this.label_wake_up = new System.Windows.Forms.Label();
            this.textbox_bedtime = new System.Windows.Forms.TextBox();
            this.textbox_duration = new System.Windows.Forms.TextBox();
            this.textbox_wake_up = new System.Windows.Forms.TextBox();
            this.textbox_remaining_time = new System.Windows.Forms.TextBox();
            this.label_remaining_time = new System.Windows.Forms.Label();
            this.checkbox_remind = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_pause
            // 
            this.button_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_pause.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_pause.Location = new System.Drawing.Point(240, 150);
            this.button_pause.Margin = new System.Windows.Forms.Padding(2);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(140, 40);
            this.button_pause.TabIndex = 0;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // textbox_time_now
            // 
            this.textbox_time_now.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_time_now.Location = new System.Drawing.Point(120, 25);
            this.textbox_time_now.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_time_now.Name = "textbox_time_now";
            this.textbox_time_now.ReadOnly = true;
            this.textbox_time_now.Size = new System.Drawing.Size(97, 34);
            this.textbox_time_now.TabIndex = 1;
            this.textbox_time_now.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_time_now.TextChanged += new System.EventHandler(this.textbox_time_now_TextChanged);
            // 
            // timer_trigger
            // 
            this.timer_trigger.Enabled = true;
            this.timer_trigger.Tick += new System.EventHandler(this.timer_trigger_Tick);
            // 
            // label_now
            // 
            this.label_now.AutoSize = true;
            this.label_now.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_now.Location = new System.Drawing.Point(38, 29);
            this.label_now.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_now.Name = "label_now";
            this.label_now.Size = new System.Drawing.Size(54, 27);
            this.label_now.TabIndex = 2;
            this.label_now.Text = "Now";
            // 
            // label_bedtime
            // 
            this.label_bedtime.AutoSize = true;
            this.label_bedtime.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_bedtime.Location = new System.Drawing.Point(22, 74);
            this.label_bedtime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_bedtime.Name = "label_bedtime";
            this.label_bedtime.Size = new System.Drawing.Size(88, 27);
            this.label_bedtime.TabIndex = 2;
            this.label_bedtime.Text = "Bedtime";
            // 
            // label_duration
            // 
            this.label_duration.AutoSize = true;
            this.label_duration.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_duration.Location = new System.Drawing.Point(21, 119);
            this.label_duration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_duration.Name = "label_duration";
            this.label_duration.Size = new System.Drawing.Size(93, 27);
            this.label_duration.TabIndex = 2;
            this.label_duration.Text = "Duration";
            // 
            // label_wake_up
            // 
            this.label_wake_up.AutoSize = true;
            this.label_wake_up.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_wake_up.Location = new System.Drawing.Point(19, 164);
            this.label_wake_up.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_wake_up.Name = "label_wake_up";
            this.label_wake_up.Size = new System.Drawing.Size(95, 27);
            this.label_wake_up.TabIndex = 2;
            this.label_wake_up.Text = "Wake-Up";
            // 
            // textbox_bedtime
            // 
            this.textbox_bedtime.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_bedtime.Location = new System.Drawing.Point(120, 70);
            this.textbox_bedtime.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_bedtime.Name = "textbox_bedtime";
            this.textbox_bedtime.Size = new System.Drawing.Size(97, 34);
            this.textbox_bedtime.TabIndex = 1;
            this.textbox_bedtime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_bedtime.TextChanged += new System.EventHandler(this.textbox_bedtime_TextChanged);
            this.textbox_bedtime.Leave += new System.EventHandler(this.textbox_bedtime_Leave);
            // 
            // textbox_duration
            // 
            this.textbox_duration.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_duration.Location = new System.Drawing.Point(120, 115);
            this.textbox_duration.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_duration.Name = "textbox_duration";
            this.textbox_duration.Size = new System.Drawing.Size(97, 34);
            this.textbox_duration.TabIndex = 1;
            this.textbox_duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_duration.TextChanged += new System.EventHandler(this.textbox_duration_TextChanged);
            this.textbox_duration.Leave += new System.EventHandler(this.textbox_duration_Leave);
            // 
            // textbox_wake_up
            // 
            this.textbox_wake_up.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_wake_up.Location = new System.Drawing.Point(120, 160);
            this.textbox_wake_up.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_wake_up.Name = "textbox_wake_up";
            this.textbox_wake_up.Size = new System.Drawing.Size(97, 34);
            this.textbox_wake_up.TabIndex = 1;
            this.textbox_wake_up.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_wake_up.TextChanged += new System.EventHandler(this.textbox_wake_up_TextChanged);
            this.textbox_wake_up.Leave += new System.EventHandler(this.textbox_wake_up_Leave);
            // 
            // textbox_remaining_time
            // 
            this.textbox_remaining_time.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_remaining_time.Location = new System.Drawing.Point(240, 60);
            this.textbox_remaining_time.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_remaining_time.Name = "textbox_remaining_time";
            this.textbox_remaining_time.ReadOnly = true;
            this.textbox_remaining_time.Size = new System.Drawing.Size(141, 47);
            this.textbox_remaining_time.TabIndex = 1;
            this.textbox_remaining_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_remaining_time.TextChanged += new System.EventHandler(this.textbox_remaining_time_TextChanged);
            // 
            // label_remaining_time
            // 
            this.label_remaining_time.AutoSize = true;
            this.label_remaining_time.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_remaining_time.Location = new System.Drawing.Point(237, 18);
            this.label_remaining_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_remaining_time.Name = "label_remaining_time";
            this.label_remaining_time.Size = new System.Drawing.Size(146, 39);
            this.label_remaining_time.TabIndex = 2;
            this.label_remaining_time.Text = "Remaning";
            // 
            // checkbox_remind
            // 
            this.checkbox_remind.AutoSize = true;
            this.checkbox_remind.Checked = true;
            this.checkbox_remind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_remind.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkbox_remind.Location = new System.Drawing.Point(260, 115);
            this.checkbox_remind.Margin = new System.Windows.Forms.Padding(2);
            this.checkbox_remind.Name = "checkbox_remind";
            this.checkbox_remind.Size = new System.Drawing.Size(101, 31);
            this.checkbox_remind.TabIndex = 3;
            this.checkbox_remind.Text = "Remind";
            this.checkbox_remind.UseVisualStyleBackColor = true;
            this.checkbox_remind.CheckedChanged += new System.EventHandler(this.checkbox_remind_CheckedChanged);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 211);
            this.Controls.Add(this.checkbox_remind);
            this.Controls.Add(this.label_wake_up);
            this.Controls.Add(this.label_duration);
            this.Controls.Add(this.label_bedtime);
            this.Controls.Add(this.label_remaining_time);
            this.Controls.Add(this.label_now);
            this.Controls.Add(this.textbox_wake_up);
            this.Controls.Add(this.textbox_duration);
            this.Controls.Add(this.textbox_bedtime);
            this.Controls.Add(this.textbox_remaining_time);
            this.Controls.Add(this.textbox_time_now);
            this.Controls.Add(this.button_pause);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Main";
            this.Text = "Bedtime Countdown Timer";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Click += new System.EventHandler(this.Form_Main_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_pause;
        private TextBox textbox_time_now;
        private System.Windows.Forms.Timer timer_trigger;
        private Label label_now;
        private Label label_bedtime;
        private Label label_duration;
        private Label label_wake_up;
        private TextBox textbox_bedtime;
        private TextBox textbox_duration;
        private TextBox textbox_wake_up;
        private TextBox textbox_remaining_time;
        private Label label_remaining_time;
        private CheckBox checkbox_remind;
    }
}
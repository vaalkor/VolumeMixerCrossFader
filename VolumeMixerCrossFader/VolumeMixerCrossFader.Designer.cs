namespace CrossMixer
{
    partial class VolumeMixerCrossFader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.alwaysOnTopCheckbox = new System.Windows.Forms.CheckBox();
            this.crossFaderBar = new System.Windows.Forms.TrackBar();
            this.firstChannelDropdown = new System.Windows.Forms.ComboBox();
            this.secondChannelDropdown = new System.Windows.Forms.ComboBox();
            this.firstChannelLabel = new System.Windows.Forms.Label();
            this.secondChannelLabel = new System.Windows.Forms.Label();
            this.firstChannelDisplayNameLabel = new System.Windows.Forms.Label();
            this.secondChannelDisplayNameLabel = new System.Windows.Forms.Label();
            this.firstChannelVolumeBar = new System.Windows.Forms.TrackBar();
            this.secondChannelVolumeBar = new System.Windows.Forms.TrackBar();
            this.autoFadeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crossFaderBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstChannelVolumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelVolumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // alwaysOnTopCheckbox
            // 
            this.alwaysOnTopCheckbox.AutoSize = true;
            this.alwaysOnTopCheckbox.Location = new System.Drawing.Point(96, 272);
            this.alwaysOnTopCheckbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.alwaysOnTopCheckbox.Name = "alwaysOnTopCheckbox";
            this.alwaysOnTopCheckbox.Size = new System.Drawing.Size(92, 17);
            this.alwaysOnTopCheckbox.TabIndex = 6;
            this.alwaysOnTopCheckbox.Text = "Always on top";
            this.alwaysOnTopCheckbox.UseVisualStyleBackColor = true;
            this.alwaysOnTopCheckbox.CheckedChanged += new System.EventHandler(this.alwaysOnTopCheckbox_CheckedChanged);
            // 
            // crossFaderBar
            // 
            this.crossFaderBar.Location = new System.Drawing.Point(23, 70);
            this.crossFaderBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crossFaderBar.Maximum = 100;
            this.crossFaderBar.Name = "crossFaderBar";
            this.crossFaderBar.Size = new System.Drawing.Size(239, 45);
            this.crossFaderBar.TabIndex = 3;
            this.crossFaderBar.TickFrequency = 5;
            this.crossFaderBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.crossFaderBar.Value = 50;
            this.crossFaderBar.Scroll += new System.EventHandler(this.crossFaderBar_Scroll);
            this.crossFaderBar.ValueChanged += new System.EventHandler(this.crossFaderBar_ValueChanged);
            // 
            // firstChannelDropdown
            // 
            this.firstChannelDropdown.FormattingEnabled = true;
            this.firstChannelDropdown.Location = new System.Drawing.Point(23, 32);
            this.firstChannelDropdown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.firstChannelDropdown.Name = "firstChannelDropdown";
            this.firstChannelDropdown.Size = new System.Drawing.Size(113, 21);
            this.firstChannelDropdown.TabIndex = 1;
            this.firstChannelDropdown.SelectedIndexChanged += new System.EventHandler(this.firstChannelDropdown_SelectedIndexChanged);
            this.firstChannelDropdown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.channelDropdown_KeyPressHandler);
            this.firstChannelDropdown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.firstChannelDropdown_MouseClick);
            // 
            // secondChannelDropdown
            // 
            this.secondChannelDropdown.FormattingEnabled = true;
            this.secondChannelDropdown.Location = new System.Drawing.Point(151, 32);
            this.secondChannelDropdown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.secondChannelDropdown.Name = "secondChannelDropdown";
            this.secondChannelDropdown.Size = new System.Drawing.Size(113, 21);
            this.secondChannelDropdown.TabIndex = 2;
            this.secondChannelDropdown.SelectedIndexChanged += new System.EventHandler(this.secondChannelDropdown_SelectedIndexChanged);
            this.secondChannelDropdown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.channelDropdown_KeyPressHandler);
            this.secondChannelDropdown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.secondChannelDropdown_MouseClick);
            // 
            // firstChannelLabel
            // 
            this.firstChannelLabel.AutoSize = true;
            this.firstChannelLabel.Location = new System.Drawing.Point(21, 10);
            this.firstChannelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.firstChannelLabel.Name = "firstChannelLabel";
            this.firstChannelLabel.Size = new System.Drawing.Size(67, 13);
            this.firstChannelLabel.TabIndex = 0;
            this.firstChannelLabel.Text = "Left Channel";
            // 
            // secondChannelLabel
            // 
            this.secondChannelLabel.AutoSize = true;
            this.secondChannelLabel.Location = new System.Drawing.Point(148, 10);
            this.secondChannelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.secondChannelLabel.Name = "secondChannelLabel";
            this.secondChannelLabel.Size = new System.Drawing.Size(74, 13);
            this.secondChannelLabel.TabIndex = 0;
            this.secondChannelLabel.Text = "Right Channel";
            // 
            // firstChannelDisplayNameLabel
            // 
            this.firstChannelDisplayNameLabel.AutoSize = true;
            this.firstChannelDisplayNameLabel.Location = new System.Drawing.Point(27, 117);
            this.firstChannelDisplayNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.firstChannelDisplayNameLabel.Name = "firstChannelDisplayNameLabel";
            this.firstChannelDisplayNameLabel.Size = new System.Drawing.Size(134, 13);
            this.firstChannelDisplayNameLabel.TabIndex = 0;
            this.firstChannelDisplayNameLabel.Text = "<First channel unselected>";
            // 
            // secondChannelDisplayNameLabel
            // 
            this.secondChannelDisplayNameLabel.AutoSize = true;
            this.secondChannelDisplayNameLabel.Location = new System.Drawing.Point(27, 192);
            this.secondChannelDisplayNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.secondChannelDisplayNameLabel.Name = "secondChannelDisplayNameLabel";
            this.secondChannelDisplayNameLabel.Size = new System.Drawing.Size(152, 13);
            this.secondChannelDisplayNameLabel.TabIndex = 0;
            this.secondChannelDisplayNameLabel.Text = "<Second channel unselected>";
            // 
            // firstChannelVolumeBar
            // 
            this.firstChannelVolumeBar.Location = new System.Drawing.Point(23, 145);
            this.firstChannelVolumeBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.firstChannelVolumeBar.Maximum = 100;
            this.firstChannelVolumeBar.Name = "firstChannelVolumeBar";
            this.firstChannelVolumeBar.Size = new System.Drawing.Size(239, 45);
            this.firstChannelVolumeBar.TabIndex = 4;
            this.firstChannelVolumeBar.TickFrequency = 5;
            this.firstChannelVolumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.firstChannelVolumeBar.Value = 50;
            this.firstChannelVolumeBar.Scroll += new System.EventHandler(this.firstChannelVolumeBar_Scroll);
            // 
            // secondChannelVolumeBar
            // 
            this.secondChannelVolumeBar.Location = new System.Drawing.Point(23, 213);
            this.secondChannelVolumeBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.secondChannelVolumeBar.Maximum = 100;
            this.secondChannelVolumeBar.Name = "secondChannelVolumeBar";
            this.secondChannelVolumeBar.Size = new System.Drawing.Size(239, 45);
            this.secondChannelVolumeBar.TabIndex = 5;
            this.secondChannelVolumeBar.TickFrequency = 5;
            this.secondChannelVolumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.secondChannelVolumeBar.Value = 50;
            this.secondChannelVolumeBar.Scroll += new System.EventHandler(this.secondChannelVolumeBar_Scroll);
            // 
            // autoFadeButton
            // 
            this.autoFadeButton.Location = new System.Drawing.Point(96, 304);
            this.autoFadeButton.Name = "autoFadeButton";
            this.autoFadeButton.Size = new System.Drawing.Size(83, 23);
            this.autoFadeButton.TabIndex = 7;
            this.autoFadeButton.Text = "Auto Fade";
            this.autoFadeButton.UseVisualStyleBackColor = true;
            this.autoFadeButton.Click += new System.EventHandler(this.autoFadeButton_MouseClick);
            // 
            // VolumeMixerCrossFader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 349);
            this.Controls.Add(this.autoFadeButton);
            this.Controls.Add(this.secondChannelVolumeBar);
            this.Controls.Add(this.firstChannelVolumeBar);
            this.Controls.Add(this.secondChannelDisplayNameLabel);
            this.Controls.Add(this.firstChannelDisplayNameLabel);
            this.Controls.Add(this.secondChannelLabel);
            this.Controls.Add(this.firstChannelLabel);
            this.Controls.Add(this.secondChannelDropdown);
            this.Controls.Add(this.firstChannelDropdown);
            this.Controls.Add(this.crossFaderBar);
            this.Controls.Add(this.alwaysOnTopCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VolumeMixerCrossFader";
            this.Text = "VolumeMixerCrossFader";
            ((System.ComponentModel.ISupportInitialize)(this.crossFaderBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstChannelVolumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelVolumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox alwaysOnTopCheckbox;
        private System.Windows.Forms.TrackBar crossFaderBar;
        private System.Windows.Forms.ComboBox firstChannelDropdown;
        private System.Windows.Forms.ComboBox secondChannelDropdown;
        private System.Windows.Forms.Label firstChannelLabel;
        private System.Windows.Forms.Label secondChannelLabel;
        private System.Windows.Forms.Label firstChannelDisplayNameLabel;
        private System.Windows.Forms.Label secondChannelDisplayNameLabel;
        private System.Windows.Forms.TrackBar firstChannelVolumeBar;
        private System.Windows.Forms.TrackBar secondChannelVolumeBar;
        private System.Windows.Forms.Button autoFadeButton;
    }
}


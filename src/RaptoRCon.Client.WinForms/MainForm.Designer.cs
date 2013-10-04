﻿namespace RaptoRCon.Client.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label hostNameLabel;
            System.Windows.Forms.Label portLabel;
            System.Windows.Forms.Label commandLabel;
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.connectionsContainer = new System.Windows.Forms.SplitContainer();
            this.connectionsDataGridView = new System.Windows.Forms.DataGridView();
            this.connectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addConnectionButton = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.hostNameTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.packetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainFormViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            hostNameLabel = new System.Windows.Forms.Label();
            portLabel = new System.Windows.Forms.Label();
            commandLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsContainer)).BeginInit();
            this.connectionsContainer.Panel1.SuspendLayout();
            this.connectionsContainer.Panel2.SuspendLayout();
            this.connectionsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hostNameLabel
            // 
            hostNameLabel.AutoSize = true;
            hostNameLabel.Location = new System.Drawing.Point(12, 13);
            hostNameLabel.Name = "hostNameLabel";
            hostNameLabel.Size = new System.Drawing.Size(63, 13);
            hostNameLabel.TabIndex = 0;
            hostNameLabel.Text = "Host Name:";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new System.Drawing.Point(12, 39);
            portLabel.Name = "portLabel";
            portLabel.Size = new System.Drawing.Size(29, 13);
            portLabel.TabIndex = 2;
            portLabel.Text = "Port:";
            // 
            // commandLabel
            // 
            commandLabel.AutoSize = true;
            commandLabel.Location = new System.Drawing.Point(14, 415);
            commandLabel.Name = "commandLabel";
            commandLabel.Size = new System.Drawing.Size(84, 13);
            commandLabel.TabIndex = 1;
            commandLabel.Text = "CommandString:";
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.connectionsContainer);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.AutoScroll = true;
            this.mainContainer.Panel2.Controls.Add(this.sendButton);
            this.mainContainer.Panel2.Controls.Add(commandLabel);
            this.mainContainer.Panel2.Controls.Add(this.commandTextBox);
            this.mainContainer.Panel2.Controls.Add(this.dataGridView1);
            this.mainContainer.Size = new System.Drawing.Size(938, 457);
            this.mainContainer.SplitterDistance = 312;
            this.mainContainer.TabIndex = 0;
            // 
            // connectionsContainer
            // 
            this.connectionsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionsContainer.Location = new System.Drawing.Point(0, 0);
            this.connectionsContainer.Name = "connectionsContainer";
            this.connectionsContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // connectionsContainer.Panel1
            // 
            this.connectionsContainer.Panel1.AutoScroll = true;
            this.connectionsContainer.Panel1.Controls.Add(this.connectionsDataGridView);
            // 
            // connectionsContainer.Panel2
            // 
            this.connectionsContainer.Panel2.AutoScroll = true;
            this.connectionsContainer.Panel2.Controls.Add(this.addConnectionButton);
            this.connectionsContainer.Panel2.Controls.Add(portLabel);
            this.connectionsContainer.Panel2.Controls.Add(this.portTextBox);
            this.connectionsContainer.Panel2.Controls.Add(hostNameLabel);
            this.connectionsContainer.Panel2.Controls.Add(this.hostNameTextBox);
            this.connectionsContainer.Size = new System.Drawing.Size(312, 457);
            this.connectionsContainer.SplitterDistance = 372;
            this.connectionsContainer.TabIndex = 0;
            // 
            // connectionsDataGridView
            // 
            this.connectionsDataGridView.AutoGenerateColumns = false;
            this.connectionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.connectionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.hostNameDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn});
            this.connectionsDataGridView.DataSource = this.connectionsBindingSource;
            this.connectionsDataGridView.Location = new System.Drawing.Point(0, 3);
            this.connectionsDataGridView.Name = "connectionsDataGridView";
            this.connectionsDataGridView.Size = new System.Drawing.Size(309, 366);
            this.connectionsDataGridView.TabIndex = 0;
            // 
            // connectionsBindingSource
            // 
            this.connectionsBindingSource.DataMember = "Connections";
            this.connectionsBindingSource.DataSource = this.mainFormViewModelBindingSource;
            // 
            // addConnectionButton
            // 
            this.addConnectionButton.Location = new System.Drawing.Point(203, 34);
            this.addConnectionButton.Name = "addConnectionButton";
            this.addConnectionButton.Size = new System.Drawing.Size(106, 23);
            this.addConnectionButton.TabIndex = 4;
            this.addConnectionButton.Text = "Add";
            this.addConnectionButton.UseVisualStyleBackColor = true;
            this.addConnectionButton.Click += new System.EventHandler(this.addConnectionButton_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainFormViewModelBindingSource, "Port", true));
            this.portTextBox.Location = new System.Drawing.Point(81, 36);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 3;
            // 
            // hostNameTextBox
            // 
            this.hostNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainFormViewModelBindingSource, "HostName", true));
            this.hostNameTextBox.Location = new System.Drawing.Point(81, 10);
            this.hostNameTextBox.Name = "hostNameTextBox";
            this.hostNameTextBox.Size = new System.Drawing.Size(228, 20);
            this.hostNameTextBox.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(431, 410);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(106, 23);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click_1);
            // 
            // commandTextBox
            // 
            this.commandTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.connectionsBindingSource, "CommandString", true));
            this.commandTextBox.Location = new System.Drawing.Point(104, 412);
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(321, 20);
            this.commandTextBox.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contentDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.packetsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(623, 366);
            this.dataGridView1.TabIndex = 0;
            // 
            // packetsBindingSource
            // 
            this.packetsBindingSource.DataMember = "Packets";
            this.packetsBindingSource.DataSource = this.connectionsBindingSource;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hostNameDataGridViewTextBoxColumn
            // 
            this.hostNameDataGridViewTextBoxColumn.DataPropertyName = "HostName";
            this.hostNameDataGridViewTextBoxColumn.HeaderText = "HostName";
            this.hostNameDataGridViewTextBoxColumn.Name = "hostNameDataGridViewTextBoxColumn";
            this.hostNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "Port";
            this.portDataGridViewTextBoxColumn.HeaderText = "Port";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            this.portDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mainFormViewModelBindingSource
            // 
            this.mainFormViewModelBindingSource.DataSource = typeof(RaptoRCon.Client.WinForms.MainFormViewModel);
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "Content";
            this.contentDataGridViewTextBoxColumn.HeaderText = "Content";
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            this.contentDataGridViewTextBoxColumn.Width = 500;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 457);
            this.Controls.Add(this.mainContainer);
            this.Name = "MainForm";
            this.Text = "RaptoRCon";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.connectionsContainer.Panel1.ResumeLayout(false);
            this.connectionsContainer.Panel2.ResumeLayout(false);
            this.connectionsContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsContainer)).EndInit();
            this.connectionsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.SplitContainer connectionsContainer;
        private System.Windows.Forms.BindingSource mainFormViewModelBindingSource;
        private System.Windows.Forms.DataGridView connectionsDataGridView;
        private System.Windows.Forms.BindingSource connectionsBindingSource;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox hostNameTextBox;
        private System.Windows.Forms.Button addConnectionButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource packetsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox commandTextBox;

    }
}


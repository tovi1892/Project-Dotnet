namespace UI_
{
    partial class Customers
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
            showCustomer = new Button();
            deleteCustomer = new Button();
            showAllCustomers = new Button();
            createCustomer = new Button();
            updateCustomer = new Button();
            panel1 = new Panel();
            textBox1 = new TextBox();
            label5 = new Label();
            confirmCreate = new Button();
            checkBox1 = new CheckBox();
            Phone = new TextBox();
            Adress = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            NameTextBox = new TextBox();
            label2 = new Label();
            panelID = new Panel();
            confirmAction = new Button();
            ID = new TextBox();
            UpName = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            UpAdress = new TextBox();
            UpPhone = new TextBox();
            checkBox2 = new CheckBox();
            UpdateConfirm = new Button();
            label6 = new Label();
            UpID = new TextBox();
            panelUpdate = new Panel();
            panelDelete = new Panel();
            DeleteConfirm = new Button();
            IDdelete = new TextBox();
            label10 = new Label();
            panelShowAll = new Panel();
            filterByClub = new Button();
            closeShowAll = new Button();
            labelFilter = new Label();
            filterTextBox = new TextBox();
            dataGridViewCustomers = new DataGridView();
            panel1.SuspendLayout();
            panelID.SuspendLayout();
            panelUpdate.SuspendLayout();
            panelDelete.SuspendLayout();
            panelShowAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            SuspendLayout();
            // 
            // showCustomer
            // 
            showCustomer.Location = new Point(594, 77);
            showCustomer.Name = "showCustomer";
            showCustomer.Size = new Size(122, 38);
            showCustomer.TabIndex = 0;
            showCustomer.Text = "Show Customer";
            showCustomer.UseVisualStyleBackColor = true;
            showCustomer.Click += showCustomer_Click;
            // 
            // deleteCustomer
            // 
            deleteCustomer.Location = new Point(594, 209);
            deleteCustomer.Name = "deleteCustomer";
            deleteCustomer.Size = new Size(122, 38);
            deleteCustomer.TabIndex = 1;
            deleteCustomer.Text = "Delete Customer";
            deleteCustomer.UseVisualStyleBackColor = true;
            deleteCustomer.Click += deleteCustomer_Click;
            // 
            // showAllCustomers
            // 
            showAllCustomers.Location = new Point(594, 121);
            showAllCustomers.Name = "showAllCustomers";
            showAllCustomers.Size = new Size(122, 38);
            showAllCustomers.TabIndex = 2;
            showAllCustomers.Text = "Show All Customers";
            showAllCustomers.UseVisualStyleBackColor = true;
            showAllCustomers.Click += showAllCustomers_Click;
            // 
            // createCustomer
            // 
            createCustomer.Location = new Point(594, 165);
            createCustomer.Name = "createCustomer";
            createCustomer.Size = new Size(122, 38);
            createCustomer.TabIndex = 2;
            createCustomer.Text = "Create Customer";
            createCustomer.UseVisualStyleBackColor = true;
            createCustomer.Click += createCustomer_Click;
            // 
            // updateCustomer
            // 
            updateCustomer.Location = new Point(594, 253);
            updateCustomer.Name = "updateCustomer";
            updateCustomer.Size = new Size(122, 38);
            updateCustomer.TabIndex = 3;
            updateCustomer.Text = "Update Customer";
            updateCustomer.UseVisualStyleBackColor = true;
            updateCustomer.Click += updateCustomer_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(confirmCreate);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(Phone);
            panel1.Controls.Add(Adress);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(NameTextBox);
            panel1.Location = new Point(31, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(197, 171);
            panel1.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(36, 23);
            textBox1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(169, 70);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 8;
            label5.Text = "ID";
            // 
            // confirmCreate
            // 
            confirmCreate.Location = new Point(78, 132);
            confirmCreate.Name = "confirmCreate";
            confirmCreate.Size = new Size(75, 23);
            confirmCreate.TabIndex = 7;
            confirmCreate.Text = "OK";
            confirmCreate.UseVisualStyleBackColor = true;
            confirmCreate.Click += confirmCreate_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(88, 109);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(99, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Club Member";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Phone
            // 
            Phone.Location = new Point(3, 44);
            Phone.Name = "Phone";
            Phone.Size = new Size(100, 23);
            Phone.TabIndex = 5;
            // 
            // Adress
            // 
            Adress.Location = new Point(3, 88);
            Adress.Name = "Adress";
            Adress.Size = new Size(100, 23);
            Adress.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 23);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 3;
            label4.Text = "Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 70);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 2;
            label3.Text = "Address";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 23);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(107, 44);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(84, 23);
            NameTextBox.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(260, 15);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 8;
            label2.Text = "Enter ID";
            // 
            // panelID
            // 
            panelID.Controls.Add(confirmAction);
            panelID.Controls.Add(ID);
            panelID.Controls.Add(label2);
            panelID.Location = new Point(118, 46);
            panelID.Name = "panelID";
            panelID.Size = new Size(339, 40);
            panelID.TabIndex = 9;
            // 
            // confirmAction
            // 
            confirmAction.Location = new Point(27, 12);
            confirmAction.Name = "confirmAction";
            confirmAction.Size = new Size(75, 23);
            confirmAction.TabIndex = 8;
            confirmAction.Text = "OK";
            confirmAction.UseVisualStyleBackColor = true;
            confirmAction.Click += confirmAction_Click;
            // 
            // ID
            // 
            ID.Location = new Point(145, 12);
            ID.Name = "ID";
            ID.Size = new Size(100, 23);
            ID.TabIndex = 8;
            // 
            // UpName
            // 
            UpName.Location = new Point(118, 94);
            UpName.Name = "UpName";
            UpName.Size = new Size(84, 23);
            UpName.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(152, 76);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 1;
            label9.Text = "Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 76);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 2;
            label8.Text = "Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(64, 11);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 3;
            label7.Text = "Phone";
            // 
            // UpAdress
            // 
            UpAdress.Location = new Point(3, 94);
            UpAdress.Name = "UpAdress";
            UpAdress.Size = new Size(100, 23);
            UpAdress.TabIndex = 4;
            // 
            // UpPhone
            // 
            UpPhone.Location = new Point(10, 29);
            UpPhone.Name = "UpPhone";
            UpPhone.Size = new Size(100, 23);
            UpPhone.TabIndex = 5;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(98, 136);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(99, 19);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "Club Member";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // UpdateConfirm
            // 
            UpdateConfirm.Location = new Point(3, 136);
            UpdateConfirm.Name = "UpdateConfirm";
            UpdateConfirm.Size = new Size(75, 23);
            UpdateConfirm.TabIndex = 7;
            UpdateConfirm.Text = "OK";
            UpdateConfirm.UseVisualStyleBackColor = true;
            UpdateConfirm.Click += UpdateConfirm_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(179, 11);
            label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 8;
            label6.Text = "ID";
            // 
            // UpID
            // 
            UpID.Location = new Point(165, 29);
            UpID.Name = "UpID";
            UpID.Size = new Size(36, 23);
            UpID.TabIndex = 9;
            // 
            // panelUpdate
            // 
            panelUpdate.Controls.Add(label6);
            panelUpdate.Controls.Add(checkBox2);
            panelUpdate.Controls.Add(label7);
            panelUpdate.Controls.Add(label8);
            panelUpdate.Controls.Add(UpAdress);
            panelUpdate.Controls.Add(UpdateConfirm);
            panelUpdate.Controls.Add(UpPhone);
            panelUpdate.Controls.Add(label9);
            panelUpdate.Controls.Add(UpID);
            panelUpdate.Controls.Add(UpName);
            panelUpdate.Location = new Point(244, 133);
            panelUpdate.Name = "panelUpdate";
            panelUpdate.Size = new Size(213, 171);
            panelUpdate.TabIndex = 10;
            panelUpdate.Paint += panelUpdate_Paint;
            // 
            // panelDelete
            // 
            panelDelete.Controls.Add(DeleteConfirm);
            panelDelete.Controls.Add(IDdelete);
            panelDelete.Controls.Add(label10);
            panelDelete.Location = new Point(118, 87);
            panelDelete.Name = "panelDelete";
            panelDelete.Size = new Size(339, 40);
            panelDelete.TabIndex = 10;
            // 
            // DeleteConfirm
            // 
            DeleteConfirm.Location = new Point(27, 12);
            DeleteConfirm.Name = "DeleteConfirm";
            DeleteConfirm.Size = new Size(75, 23);
            DeleteConfirm.TabIndex = 8;
            DeleteConfirm.Text = "OK";
            DeleteConfirm.UseVisualStyleBackColor = true;
            DeleteConfirm.Click += DeleteConfirm_Click;
            // 
            // IDdelete
            // 
            IDdelete.Location = new Point(145, 12);
            IDdelete.Name = "IDdelete";
            IDdelete.Size = new Size(100, 23);
            IDdelete.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(260, 15);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 8;
            label10.Text = "Enter ID";
            // 
            // panelShowAll
            // 
            panelShowAll.Controls.Add(filterByClub);
            panelShowAll.Controls.Add(closeShowAll);
            panelShowAll.Controls.Add(labelFilter);
            panelShowAll.Controls.Add(filterTextBox);
            panelShowAll.Controls.Add(dataGridViewCustomers);
            panelShowAll.Location = new Point(14, 46);
            panelShowAll.Name = "panelShowAll";
            panelShowAll.Size = new Size(566, 265);
            panelShowAll.TabIndex = 11;
            // 
            // filterByClub
            // 
            filterByClub.Location = new Point(249, 10);
            filterByClub.Margin = new Padding(2, 2, 2, 2);
            filterByClub.Name = "filterByClub";
            filterByClub.Size = new Size(179, 20);
            filterByClub.TabIndex = 4;
            filterByClub.Text = "only club members";
            filterByClub.UseVisualStyleBackColor = true;
            filterByClub.Click += filterByClub_Click;
            // 
            // closeShowAll
            // 
            closeShowAll.Location = new Point(493, 9);
            closeShowAll.Name = "closeShowAll";
            closeShowAll.Size = new Size(55, 19);
            closeShowAll.TabIndex = 3;
            closeShowAll.Text = "X";
            closeShowAll.UseVisualStyleBackColor = true;
            closeShowAll.Click += closeShowAll_Click;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(10, 12);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(36, 15);
            labelFilter.TabIndex = 2;
            labelFilter.Text = "Filter:";
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(65, 7);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.PlaceholderText = "Search by Name";
            filterTextBox.Size = new Size(123, 23);
            filterTextBox.TabIndex = 1;
            filterTextBox.TextChanged += filterTextBox_TextChanged;
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Location = new Point(10, 33);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.ReadOnly = true;
            dataGridViewCustomers.RowHeadersWidth = 62;
            dataGridViewCustomers.Size = new Size(537, 221);
            dataGridViewCustomers.TabIndex = 0;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelShowAll);
            Controls.Add(panelDelete);
            Controls.Add(panelUpdate);
            Controls.Add(panelID);
            Controls.Add(panel1);
            Controls.Add(updateCustomer);
            Controls.Add(createCustomer);
            Controls.Add(showAllCustomers);
            Controls.Add(deleteCustomer);
            Controls.Add(showCustomer);
            Name = "Customers";
            Text = "Customers";
            Load += Customers_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelID.ResumeLayout(false);
            panelID.PerformLayout();
            panelUpdate.ResumeLayout(false);
            panelUpdate.PerformLayout();
            panelDelete.ResumeLayout(false);
            panelDelete.PerformLayout();
            panelShowAll.ResumeLayout(false);
            panelShowAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button showCustomer;
        private Button deleteCustomer;
        private Button showAllCustomers;
        private Button createCustomer;
        private Button updateCustomer;
        private Panel panel1;
        private Label label1;
        private TextBox NameTextBox;
        private Label label4;
        private Label label3;
        private TextBox Phone;
        private TextBox Adress;
        private CheckBox checkBox1;
        private Button confirmCreate;
        private Label label2;
        private Panel panelID;
        private TextBox ID;
        private Button confirmAction;
        private TextBox textBox1;
        private Label label5;
        private Panel panelUpdate;
        private TextBox UpName;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox UpAdress;
        private TextBox UpPhone;
        private CheckBox checkBox2;
        private Button UpdateConfirm;
        private Label label6;
        private TextBox UpID;
        private Panel panelDelete;
        private Button DeleteConfirm;
        private TextBox IDdelete;
        private Label label10;
        private Panel panelShowAll;
        private DataGridView dataGridViewCustomers;
        private TextBox filterTextBox;
        private Label labelFilter;
        private Button closeShowAll;
        private Button filterByClub;
    }
}
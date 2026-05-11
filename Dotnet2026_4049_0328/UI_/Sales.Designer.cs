namespace UI_
{
    partial class Sales
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
            showSale = new Button();
            deleteSale = new Button();
   showAllSales = new Button();
            createSale = new Button();
            updateSale = new Button();
            panel1 = new Panel();
            endDatePicker = new DateTimePicker();
      startDatePicker = new DateTimePicker();
            clubCheckBox = new CheckBox();
            costTextBox = new TextBox();
     amountTextBox = new TextBox();
            productComboBox = new ComboBox();
          confirmCreate = new Button();
            label5 = new Label();
  label4 = new Label();
        label3 = new Label();
 label2 = new Label();
            label1 = new Label();
      panelID = new Panel();
            confirmAction = new Button();
 idTextBox = new TextBox();
    labelID = new Label();
 panelUpdate = new Panel();
  upEndDatePicker = new DateTimePicker();
            upStartDatePicker = new DateTimePicker();
       clubCheckBoxUpdate = new CheckBox();
            upCostTextBox = new TextBox();
          upAmountTextBox = new TextBox();
     productComboBoxUpdate = new ComboBox();
            UpdateConfirm = new Button();
    label10 = new Label();
   label9 = new Label();
 label8 = new Label();
          label7 = new Label();
 label6 = new Label();
            upIdTextBox = new TextBox();
    panelDelete = new Panel();
       DeleteConfirm = new Button();
            idDeleteTextBox = new TextBox();
      labelIDDelete = new Label();
     panelShowAll = new Panel();
            filterByProduct = new Button();
 filterByClub = new Button();
closeShowAll = new Button();
            labelFilter = new Label();
            filterTextBox = new TextBox();
      dataGridViewSales = new DataGridView();
      productFilterComboBox = new ComboBox();
            label12 = new Label();
panel1.SuspendLayout();
        panelID.SuspendLayout();
            panelUpdate.SuspendLayout();
            panelDelete.SuspendLayout();
          panelShowAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).BeginInit();
  SuspendLayout();
      // 
      // showSale
       // 
    showSale.Location = new Point(594, 77);
    showSale.Name = "showSale";
      showSale.Size = new Size(122, 38);
   showSale.TabIndex = 0;
   showSale.Text = "Show Sale";
        showSale.UseVisualStyleBackColor = true;
    showSale.Click += showSale_Click;
            // 
 // deleteSale
            // 
   deleteSale.Location = new Point(594, 209);
       deleteSale.Name = "deleteSale";
       deleteSale.Size = new Size(122, 38);
            deleteSale.TabIndex = 1;
     deleteSale.Text = "Delete Sale";
            deleteSale.UseVisualStyleBackColor = true;
   deleteSale.Click += deleteSale_Click;
    // 
 // showAllSales
   // 
            showAllSales.Location = new Point(594, 121);
  showAllSales.Name = "showAllSales";
     showAllSales.Size = new Size(122, 38);
 showAllSales.TabIndex = 2;
         showAllSales.Text = "Show All Sales";
            showAllSales.UseVisualStyleBackColor = true;
            showAllSales.Click += showAllSales_Click;
            // 
 // createSale
            // 
            createSale.Location = new Point(594, 165);
  createSale.Name = "createSale";
       createSale.Size = new Size(122, 38);
     createSale.TabIndex = 2;
            createSale.Text = "Create Sale";
        createSale.UseVisualStyleBackColor = true;
  createSale.Click += createSale_Click;
            // 
            // updateSale
            // 
   updateSale.Location = new Point(594, 253);
            updateSale.Name = "updateSale";
 updateSale.Size = new Size(122, 38);
            updateSale.TabIndex = 3;
updateSale.Text = "Update Sale";
            updateSale.UseVisualStyleBackColor = true;
   updateSale.Click += updateSale_Click;
            // 
      // panel1
         // 
     panel1.Controls.Add(endDatePicker);
 panel1.Controls.Add(startDatePicker);
            panel1.Controls.Add(clubCheckBox);
  panel1.Controls.Add(costTextBox);
      panel1.Controls.Add(amountTextBox);
  panel1.Controls.Add(productComboBox);
            panel1.Controls.Add(confirmCreate);
    panel1.Controls.Add(label5);
        panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
      panel1.Controls.Add(label2);
     panel1.Controls.Add(label1);
       panel1.Location = new Point(31, 133);
            panel1.Name = "panel1";
     panel1.Size = new Size(197, 230);
       panel1.TabIndex = 4;
      // 
            // endDatePicker
            // 
  endDatePicker.Location = new Point(98, 181);
            endDatePicker.Name = "endDatePicker";
 endDatePicker.Size = new Size(92, 23);
    endDatePicker.TabIndex = 11;
   // 
       // startDatePicker
       // 
   startDatePicker.Location = new Point(3, 181);
        startDatePicker.Name = "startDatePicker";
   startDatePicker.Size = new Size(92, 23);
            startDatePicker.TabIndex = 10;
            // 
       // clubCheckBox
       // 
            clubCheckBox.AutoSize = true;
     clubCheckBox.Location = new Point(3, 155);
      clubCheckBox.Name = "clubCheckBox";
            clubCheckBox.Size = new Size(99, 19);
        clubCheckBox.TabIndex = 9;
       clubCheckBox.Text = "Club Members";
            clubCheckBox.UseVisualStyleBackColor = true;
            // 
            // costTextBox
 // 
            costTextBox.Location = new Point(98, 110);
            costTextBox.Name = "costTextBox";
  costTextBox.Size = new Size(92, 23);
            costTextBox.TabIndex = 8;
  // 
            // amountTextBox
      // 
         amountTextBox.Location = new Point(3, 110);
         amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(92, 23);
            amountTextBox.TabIndex = 7;
       // 
            // productComboBox
      // 
       productComboBox.FormattingEnabled = true;
            productComboBox.Location = new Point(3, 66);
 productComboBox.Name = "productComboBox";
   productComboBox.Size = new Size(188, 23);
            productComboBox.TabIndex = 6;
            // 
            // confirmCreate
  // 
            confirmCreate.Location = new Point(78, 207);
    confirmCreate.Name = "confirmCreate";
    confirmCreate.Size = new Size(75, 23);
            confirmCreate.TabIndex = 5;
   confirmCreate.Text = "OK";
          confirmCreate.UseVisualStyleBackColor = true;
     confirmCreate.Click += confirmCreate_Click;
     // 
            // label5
        // 
         label5.AutoSize = true;
        label5.Location = new Point(3, 161);
label5.Name = "label5";
      label5.Size = new Size(62, 15);
            label5.TabIndex = 4;
            label5.Text = "End Date";
    // 
            // label4
            // 
      label4.AutoSize = true;
            label4.Location = new Point(98, 92);
            label4.Name = "label4";
       label4.Size = new Size(31, 15);
            label4.TabIndex = 3;
            label4.Text = "Cost";
       // 
            // label3
       // 
         label3.AutoSize = true;
      label3.Location = new Point(3, 92);
  label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
       label3.Text = "Amount";
            // 
            // label2
   // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 46);
      label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 1;
            label2.Text = "Product";
            // 
        // label1
          // 
      label1.AutoSize = true;
            label1.Location = new Point(3, 161);
   label1.Name = "label1";
  label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Start Date";
   // 
 // panelID
     // 
    panelID.Controls.Add(confirmAction);
panelID.Controls.Add(idTextBox);
   panelID.Controls.Add(labelID);
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
            // idTextBox
         // 
    idTextBox.Location = new Point(145, 12);
idTextBox.Name = "idTextBox";
     idTextBox.Size = new Size(100, 23);
            idTextBox.TabIndex = 8;
      // 
      // labelID
            // 
            labelID.AutoSize = true;
          labelID.Location = new Point(260, 15);
labelID.Name = "labelID";
     labelID.Size = new Size(48, 15);
     labelID.TabIndex = 8;
            labelID.Text = "Enter ID";
         // 
            // panelUpdate
     // 
    panelUpdate.Controls.Add(upEndDatePicker);
     panelUpdate.Controls.Add(upStartDatePicker);
  panelUpdate.Controls.Add(clubCheckBoxUpdate);
            panelUpdate.Controls.Add(upCostTextBox);
            panelUpdate.Controls.Add(upAmountTextBox);
          panelUpdate.Controls.Add(productComboBoxUpdate);
            panelUpdate.Controls.Add(UpdateConfirm);
    panelUpdate.Controls.Add(label10);
      panelUpdate.Controls.Add(label9);
   panelUpdate.Controls.Add(label8);
   panelUpdate.Controls.Add(label7);
    panelUpdate.Controls.Add(label6);
    panelUpdate.Controls.Add(upIdTextBox);
    panelUpdate.Location = new Point(244, 133);
   panelUpdate.Name = "panelUpdate";
  panelUpdate.Size = new Size(213, 230);
            panelUpdate.TabIndex = 10;
            // 
            // upEndDatePicker
            // 
        upEndDatePicker.Location = new Point(108, 181);
        upEndDatePicker.Name = "upEndDatePicker";
 upEndDatePicker.Size = new Size(92, 23);
     upEndDatePicker.TabIndex = 13;
            // 
       // upStartDatePicker
            // 
            upStartDatePicker.Location = new Point(3, 181);
            upStartDatePicker.Name = "upStartDatePicker";
  upStartDatePicker.Size = new Size(92, 23);
     upStartDatePicker.TabIndex = 12;
 // 
            // clubCheckBoxUpdate
    // 
            clubCheckBoxUpdate.AutoSize = true;
        clubCheckBoxUpdate.Location = new Point(3, 155);
   clubCheckBoxUpdate.Name = "clubCheckBoxUpdate";
   clubCheckBoxUpdate.Size = new Size(99, 19);
    clubCheckBoxUpdate.TabIndex = 11;
        clubCheckBoxUpdate.Text = "Club Members";
            clubCheckBoxUpdate.UseVisualStyleBackColor = true;
// 
         // upCostTextBox
            // 
upCostTextBox.Location = new Point(108, 110);
upCostTextBox.Name = "upCostTextBox";
     upCostTextBox.Size = new Size(92, 23);
       upCostTextBox.TabIndex = 8;
    // 
  // upAmountTextBox
      // 
      upAmountTextBox.Location = new Point(3, 110);
            upAmountTextBox.Name = "upAmountTextBox";
            upAmountTextBox.Size = new Size(92, 23);
    upAmountTextBox.TabIndex = 7;
// 
          // productComboBoxUpdate
     // 
    productComboBoxUpdate.FormattingEnabled = true;
     productComboBoxUpdate.Location = new Point(3, 66);
       productComboBoxUpdate.Name = "productComboBoxUpdate";
 productComboBoxUpdate.Size = new Size(188, 23);
     productComboBoxUpdate.TabIndex = 6;
    // 
            // UpdateConfirm
            // 
          UpdateConfirm.Location = new Point(73, 207);
         UpdateConfirm.Name = "UpdateConfirm";
            UpdateConfirm.Size = new Size(75, 23);
            UpdateConfirm.TabIndex = 5;
     UpdateConfirm.Text = "OK";
            UpdateConfirm.UseVisualStyleBackColor = true;
    UpdateConfirm.Click += UpdateConfirm_Click;
    // 
         // label10
            // 
  label10.AutoSize = true;
 label10.Location = new Point(3, 161);
 label10.Name = "label10";
            label10.Size = new Size(62, 15);
  label10.TabIndex = 4;
     label10.Text = "End Date";
            // 
            // label9
   // 
         label9.AutoSize = true;
            label9.Location = new Point(108, 92);
 label9.Name = "label9";
  label9.Size = new Size(31, 15);
   label9.TabIndex = 3;
    label9.Text = "Cost";
            // 
       // label8
// 
    label8.AutoSize = true;
   label8.Location = new Point(3, 92);
            label8.Name = "label8";
     label8.Size = new Size(54, 15);
        label8.TabIndex = 2;
       label8.Text = "Amount";
  // 
          // label7
            // 
      label7.AutoSize = true;
            label7.Location = new Point(3, 46);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 1;
            label7.Text = "Product";
            // 
            // label6
    // 
   label6.AutoSize = true;
            label6.Location = new Point(3, 12);
   label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 1;
            label6.Text = "ID";
  // 
       // upIdTextBox
            // 
            upIdTextBox.Location = new Point(3, 32);
            upIdTextBox.Name = "upIdTextBox";
     upIdTextBox.Size = new Size(60, 23);
 upIdTextBox.TabIndex = 0;
   // 
    // panelDelete
            // 
            panelDelete.Controls.Add(DeleteConfirm);
         panelDelete.Controls.Add(idDeleteTextBox);
            panelDelete.Controls.Add(labelIDDelete);
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
         // idDeleteTextBox
          // 
         idDeleteTextBox.Location = new Point(145, 12);
            idDeleteTextBox.Name = "idDeleteTextBox";
            idDeleteTextBox.Size = new Size(100, 23);
         idDeleteTextBox.TabIndex = 8;
            // 
            // labelIDDelete
            // 
            labelIDDelete.AutoSize = true;
          labelIDDelete.Location = new Point(260, 15);
     labelIDDelete.Name = "labelIDDelete";
            labelIDDelete.Size = new Size(48, 15);
            labelIDDelete.TabIndex = 8;
            labelIDDelete.Text = "Enter ID";
       // 
            // panelShowAll
  // 
            panelShowAll.Controls.Add(filterByProduct);
panelShowAll.Controls.Add(label12);
panelShowAll.Controls.Add(productFilterComboBox);
            panelShowAll.Controls.Add(filterByClub);
            panelShowAll.Controls.Add(closeShowAll);
         panelShowAll.Controls.Add(labelFilter);
    panelShowAll.Controls.Add(filterTextBox);
      panelShowAll.Controls.Add(dataGridViewSales);
   panelShowAll.Location = new Point(14, 46);
   panelShowAll.Name = "panelShowAll";
    panelShowAll.Size = new Size(566, 265);
    panelShowAll.TabIndex = 11;
    // 
          // filterByProduct
       // 
    filterByProduct.Location = new Point(249, 50);
            filterByProduct.Margin = new Padding(2, 2, 2, 2);
  filterByProduct.Name = "filterByProduct";
    filterByProduct.Size = new Size(179, 20);
   filterByProduct.TabIndex = 7;
            filterByProduct.Text = "Filter by Product";
            filterByProduct.UseVisualStyleBackColor = true;
            filterByProduct.Click += filterByProduct_Click;
      // 
            // filterByClub
// 
          filterByClub.Location = new Point(249, 30);
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
          filterTextBox.PlaceholderText = "Search by Product ID";
      filterTextBox.Size = new Size(123, 23);
     filterTextBox.TabIndex = 1;
            filterTextBox.TextChanged += filterTextBox_TextChanged;
            // 
            // dataGridViewSales
         // 
         dataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
     dataGridViewSales.Location = new Point(10, 73);
      dataGridViewSales.Name = "dataGridViewSales";
            dataGridViewSales.ReadOnly = true;
    dataGridViewSales.RowHeadersWidth = 62;
         dataGridViewSales.Size = new Size(537, 181);
   dataGridViewSales.TabIndex = 0;
   // 
            // productFilterComboBox
     // 
            productFilterComboBox.FormattingEnabled = true;
            productFilterComboBox.Location = new Point(65, 50);
  productFilterComboBox.Name = "productFilterComboBox";
 productFilterComboBox.Size = new Size(123, 23);
       productFilterComboBox.TabIndex = 8;
            // 
     // label12
            // 
       label12.AutoSize = true;
        label12.Location = new Point(10, 53);
   label12.Name = "label12";
         label12.Size = new Size(50, 15);
     label12.TabIndex = 2;
            label12.Text = "Product:";
    // 
       // Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(800, 450);
     Controls.Add(panelShowAll);
   Controls.Add(panelDelete);
    Controls.Add(panelUpdate);
            Controls.Add(panelID);
         Controls.Add(panel1);
        Controls.Add(updateSale);
    Controls.Add(createSale);
Controls.Add(showAllSales);
   Controls.Add(deleteSale);
       Controls.Add(showSale);
   Name = "Sales";
            Text = "Sales";
            Load += Sales_Load;
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
    ((System.ComponentModel.ISupportInitialize)dataGridViewSales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button showSale;
        private Button deleteSale;
 private Button showAllSales;
        private Button createSale;
        private Button updateSale;
        private Panel panel1;
  private Label label1;
        private TextBox amountTextBox;
     private TextBox costTextBox;
private ComboBox productComboBox;
        private Button confirmCreate;
        private Label label2;
   private Label label3;
   private Label label4;
        private CheckBox clubCheckBox;
      private Label label5;
      private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Panel panelID;
        private TextBox idTextBox;
        private Button confirmAction;
   private Panel panelUpdate;
        private TextBox upAmountTextBox;
        private TextBox upCostTextBox;
        private ComboBox productComboBoxUpdate;
        private Button UpdateConfirm;
  private Label label6;
      private Label label7;
        private Label label8;
        private Label label9;
   private Label label10;
        private TextBox upIdTextBox;
        private CheckBox clubCheckBoxUpdate;
        private DateTimePicker upStartDatePicker;
        private DateTimePicker upEndDatePicker;
        private Panel panelDelete;
 private Button DeleteConfirm;
   private TextBox idDeleteTextBox;
        private Panel panelShowAll;
        private DataGridView dataGridViewSales;
        private TextBox filterTextBox;
        private Label labelFilter;
        private Button closeShowAll;
        private Label labelID;
        private Button filterByClub;
        private Button filterByProduct;
  private ComboBox productFilterComboBox;
   private Label label12;
        private Label labelIDDelete;
    }
}

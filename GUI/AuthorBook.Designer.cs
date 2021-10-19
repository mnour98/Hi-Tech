namespace Hi_Tech.GUI
{
    partial class AuthorBooksForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.iSBNAthorBook = new System.Windows.Forms.TextBox();
            this.authorBookIDtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PublisherIdtextbox = new System.Windows.Forms.TextBox();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.List = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.AuthorBooktextBoxCat = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ISBN:";
            // 
            // iSBNAthorBook
            // 
            this.iSBNAthorBook.Location = new System.Drawing.Point(86, 86);
            this.iSBNAthorBook.Name = "iSBNAthorBook";
            this.iSBNAthorBook.Size = new System.Drawing.Size(118, 20);
            this.iSBNAthorBook.TabIndex = 12;
            // 
            // authorBookIDtextBox
            // 
            this.authorBookIDtextBox.Location = new System.Drawing.Point(86, 45);
            this.authorBookIDtextBox.Name = "authorBookIDtextBox";
            this.authorBookIDtextBox.Size = new System.Drawing.Size(118, 20);
            this.authorBookIDtextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Author ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Edition ";
            // 
            // edition
            // 
            this.edition.Location = new System.Drawing.Point(82, 127);
            this.edition.Name = "edition";
            this.edition.Size = new System.Drawing.Size(122, 20);
            this.edition.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Published year";
            // 
            // PublisherIdtextbox
            // 
            this.PublisherIdtextbox.Location = new System.Drawing.Point(82, 181);
            this.PublisherIdtextbox.Name = "PublisherIdtextbox";
            this.PublisherIdtextbox.Size = new System.Drawing.Size(122, 20);
            this.PublisherIdtextbox.TabIndex = 16;
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(644, 33);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(267, 362);
            this.dataGridView6.TabIndex = 18;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(267, 165);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 50);
            this.button3.TabIndex = 21;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 49);
            this.button2.TabIndex = 20;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 42);
            this.button1.TabIndex = 19;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // List
            // 
            this.List.Location = new System.Drawing.Point(533, 95);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(75, 48);
            this.List.TabIndex = 22;
            this.List.Text = "List Author Books";
            this.List.UseVisualStyleBackColor = true;
            this.List.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.AuthorBooktextBoxCat);
            this.groupBox2.Location = new System.Drawing.Point(344, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 142);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(17, 28);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(162, 34);
            this.button6.TabIndex = 24;
            this.button6.Text = "Search";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AuthorBooktextBoxCat
            // 
            this.AuthorBooktextBoxCat.Location = new System.Drawing.Point(111, 81);
            this.AuthorBooktextBoxCat.Name = "AuthorBooktextBoxCat";
            this.AuthorBooktextBoxCat.Size = new System.Drawing.Size(162, 20);
            this.AuthorBooktextBoxCat.TabIndex = 25;
            this.AuthorBooktextBoxCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(165, 346);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 45);
            this.button5.TabIndex = 32;
            this.button5.Text = "EXIT";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(51, 346);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(92, 45);
            this.button7.TabIndex = 31;
            this.button7.Text = "Main Menu";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // AuthorBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 407);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.List);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PublisherIdtextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iSBNAthorBook);
            this.Controls.Add(this.authorBookIDtextBox);
            this.Controls.Add(this.label1);
            this.Name = "AuthorBooksForm";
            this.Text = "Author Books";
            this.Load += new System.EventHandler(this.AuthorBookscs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox iSBNAthorBook;
        private System.Windows.Forms.TextBox authorBookIDtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PublisherIdtextbox;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button List;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox AuthorBooktextBoxCat;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
    }
}
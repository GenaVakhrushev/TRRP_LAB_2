
namespace TRRP_Lab_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pathText = new System.Windows.Forms.TextBox();
            this.changeFileButton = new System.Windows.Forms.Button();
            this.openFileDb = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.IpMQTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите файл ненормализованной базы данных";
            // 
            // pathText
            // 
            this.pathText.Location = new System.Drawing.Point(12, 29);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(291, 22);
            this.pathText.TabIndex = 1;
            this.pathText.Text = "D:\\Учёба\\4 курс\\1трим\\ТРРП\\TRRP_Lab_2\\TRRP_Lab_2\\bin\\Debug\\apteka_db.sqlite";
            // 
            // changeFileButton
            // 
            this.changeFileButton.Location = new System.Drawing.Point(309, 29);
            this.changeFileButton.Name = "changeFileButton";
            this.changeFileButton.Size = new System.Drawing.Size(44, 23);
            this.changeFileButton.TabIndex = 2;
            this.changeFileButton.Text = "...";
            this.changeFileButton.UseVisualStyleBackColor = true;
            this.changeFileButton.Click += new System.EventHandler(this.changeFileButton_Click);
            // 
            // openFileDb
            // 
            this.openFileDb.FileName = "D:\\4 курс\\ТРРП\\Входной\\sales.db";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(341, 157);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.PortTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.IpTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(333, 128);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Socket";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Нормализовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(179, 27);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(100, 22);
            this.PortTextBox.TabIndex = 3;
            this.PortTextBox.Text = "34000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Порт";
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(10, 28);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(118, 22);
            this.IpTextBox.TabIndex = 1;
            this.IpTextBox.Text = "192.168.0.16";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ip-адрес сервера";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PassTextBox);
            this.tabPage2.Controls.Add(this.LoginTextBox);
            this.tabPage2.Controls.Add(this.IpMQTextBox);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(333, 128);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Message queue";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PassTextBox
            // 
            this.PassTextBox.Location = new System.Drawing.Point(134, 63);
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(153, 22);
            this.PassTextBox.TabIndex = 6;
            this.PassTextBox.Text = "pass";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(134, 35);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(153, 22);
            this.LoginTextBox.TabIndex = 5;
            this.LoginTextBox.Text = "user";
            // 
            // IpMQTextBox
            // 
            this.IpMQTextBox.Location = new System.Drawing.Point(134, 7);
            this.IpMQTextBox.Name = "IpMQTextBox";
            this.IpMQTextBox.Size = new System.Drawing.Size(153, 22);
            this.IpMQTextBox.TabIndex = 4;
            this.IpMQTextBox.Text = "192.168.0.16";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(317, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Нормализовать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Пароль";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Логин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ip-адрес сервера";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 217);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.changeFileButton);
            this.Controls.Add(this.pathText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Client";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.Button changeFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PassTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox IpMQTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}


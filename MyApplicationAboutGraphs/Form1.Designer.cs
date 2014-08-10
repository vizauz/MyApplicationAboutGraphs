namespace MyApplicationAboutGraphs
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEdges = new System.Windows.Forms.Label();
            this.labelPossibleEdges = new System.Windows.Forms.Label();
            this.labelVertices = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonFindPath = new System.Windows.Forms.Button();
            this.buttonMinSpanTree = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.canvas.Location = new System.Drawing.Point(12, 27);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(600, 354);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.richTextBox1.Location = new System.Drawing.Point(12, 387);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(794, 99);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(618, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "INFORMATION";
            // 
            // labelEdges
            // 
            this.labelEdges.AutoSize = true;
            this.labelEdges.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEdges.Location = new System.Drawing.Point(618, 49);
            this.labelEdges.Name = "labelEdges";
            this.labelEdges.Size = new System.Drawing.Size(56, 17);
            this.labelEdges.TabIndex = 3;
            this.labelEdges.Text = "Edges:";
            // 
            // labelPossibleEdges
            // 
            this.labelPossibleEdges.AutoSize = true;
            this.labelPossibleEdges.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPossibleEdges.Location = new System.Drawing.Point(618, 83);
            this.labelPossibleEdges.Name = "labelPossibleEdges";
            this.labelPossibleEdges.Size = new System.Drawing.Size(128, 17);
            this.labelPossibleEdges.TabIndex = 4;
            this.labelPossibleEdges.Text = "Possible edges:";
            // 
            // labelVertices
            // 
            this.labelVertices.AutoSize = true;
            this.labelVertices.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVertices.Location = new System.Drawing.Point(618, 66);
            this.labelVertices.Name = "labelVertices";
            this.labelVertices.Size = new System.Drawing.Size(80, 17);
            this.labelVertices.TabIndex = 5;
            this.labelVertices.Text = "Vertices:";
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReset.Location = new System.Drawing.Point(621, 129);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(77, 60);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonFindPath
            // 
            this.buttonFindPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFindPath.Location = new System.Drawing.Point(621, 321);
            this.buttonFindPath.Name = "buttonFindPath";
            this.buttonFindPath.Size = new System.Drawing.Size(185, 60);
            this.buttonFindPath.TabIndex = 7;
            this.buttonFindPath.Text = "FIND SHORT PATH";
            this.buttonFindPath.UseVisualStyleBackColor = true;
            this.buttonFindPath.Click += new System.EventHandler(this.buttonFindPath_Click);
            // 
            // buttonMinSpanTree
            // 
            this.buttonMinSpanTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinSpanTree.Location = new System.Drawing.Point(621, 225);
            this.buttonMinSpanTree.Name = "buttonMinSpanTree";
            this.buttonMinSpanTree.Size = new System.Drawing.Size(185, 60);
            this.buttonMinSpanTree.TabIndex = 8;
            this.buttonMinSpanTree.Text = "MIN SPAN TREE";
            this.buttonMinSpanTree.UseVisualStyleBackColor = true;
            this.buttonMinSpanTree.Click += new System.EventHandler(this.buttonMinSpanTree_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(729, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 60);
            this.button1.TabIndex = 9;
            this.button1.Text = "CLEAR ALL PATHES";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGraphToolStripMenuItem,
            this.openGraphToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveGraphToolStripMenuItem
            // 
            this.saveGraphToolStripMenuItem.Name = "saveGraphToolStripMenuItem";
            this.saveGraphToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveGraphToolStripMenuItem.Text = "&Save graph";
            this.saveGraphToolStripMenuItem.Click += new System.EventHandler(this.saveGraphToolStripMenuItem_Click);
            // 
            // openGraphToolStripMenuItem
            // 
            this.openGraphToolStripMenuItem.Name = "openGraphToolStripMenuItem";
            this.openGraphToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openGraphToolStripMenuItem.Text = "&Open graph";
            this.openGraphToolStripMenuItem.Click += new System.EventHandler(this.openGraphToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonMinSpanTree);
            this.Controls.Add(this.buttonFindPath);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelVertices);
            this.Controls.Add(this.labelPossibleEdges);
            this.Controls.Add(this.labelEdges);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Grapher v0.1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEdges;
        private System.Windows.Forms.Label labelPossibleEdges;
        private System.Windows.Forms.Label labelVertices;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonFindPath;
        private System.Windows.Forms.Button buttonMinSpanTree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


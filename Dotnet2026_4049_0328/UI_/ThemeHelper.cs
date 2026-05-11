using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI_
{
    public static class ThemeHelper
    {
        // פלטת צבעים יוקרתית - חנות תכשיטים
        public static Color BackgroundColor = Color.FromArgb(252, 251, 245); // פנינה/בז' עדין
        public static Color AccentGold = Color.FromArgb(197, 160, 82);      // זהב יוקרתי
        public static Color DarkText = Color.FromArgb(45, 45, 45);          // אפור פחם לטקסט
        public static Color PanelBg = Color.White;
        public static Color ButtonHover = Color.FromArgb(218, 188, 120);

        public static void Apply(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = new Font("Segoe UI", 10);

            foreach (Control ctrl in form.Controls)
            {
                ApplyToControl(ctrl);
            }
        }

        private static void ApplyToControl(Control ctrl)
        {
            // עיצוב כפתורים
            if (ctrl is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = AccentGold;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
            }
            // עיצוב פאנלים
            else if (ctrl is Panel pnl)
            {
                pnl.BackColor = PanelBg;
                foreach (Control child in pnl.Controls) ApplyToControl(child);
            }
            // עיצוב טבלאות (מנהל וקופאי)
            else if (ctrl is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = AccentGold;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                //dgv.SelectionBackColor = Color.FromArgb(245, 230, 200);
                //dgv.SelectionForeColor = Color.Black;
            }
            // עיצוב כותרות
            else if (ctrl is Label lbl && (lbl.Name.Contains("Title") || lbl.Name == "label1"))
            {
                lbl.Font = new Font("Cambria", 16, FontStyle.Bold);
                lbl.ForeColor = AccentGold;
            }

            // קריאה רקורסיבית למקרה שיש פקדים בתוך פקדים
            if (ctrl.HasChildren)
            {
                foreach (Control child in ctrl.Controls) ApplyToControl(child);
            }
        }
    }
}
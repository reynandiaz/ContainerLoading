using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace HTIPackageAllocation.NetCfLibrary
{
    public static class MessageBoxEx
    {
        public static void ShowInformation(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);
        }

        public static void ShowExclamation(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowExclamation(string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, "Message", buttons, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowExclamation(string message, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(message, "Message", buttons, MessageBoxIcon.Exclamation,
                defaultButton);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1);
        }

        public static void ShowError(Exception exc)
        {
#if DEBUG
            ShowError(exc.ToString());
#else
            ShowError(exc.Message);
#endif
        }

        public static DialogResult ShowQuestion(string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, "Message", buttons, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowQuestion(string message, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(message, "Message", buttons, MessageBoxIcon.Question,
                defaultButton);
        }
    }
}

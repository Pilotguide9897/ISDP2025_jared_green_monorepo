using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace idsp2025_jared_green.Helpers
{
    internal static class ValidateInput
    {
        // Logic for confirming that the supplied password matches the required parameters:
        // 1. At least 8 characters long.
        // 2. At least 1 non-numeric character.
        // 3. At least 1 character that is capitalized.
        // 4. At least 1 numeric character.
        public static bool ValidatePassword(string suppliedPassword)
        {
            // This regular expression attempts to match all the password requirements. It contains positive lookahead 
            // groups for at least one non-numeric character, at least one capitalized letter, and at least one numeric
            // character. It also requires that it consist of eight or more, non-whitespace characters. In addition, it contains 
            // a negative lookahead to make sure that the new password does not contain the default password, to prevent 
            // it from being set back exactly to what it was.

            string passwordPattern = "^(?!P@ssw0rd-)(?=.*[0-9])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])\\S{8,}$";
            Regex regex = new Regex(passwordPattern);
            // The regex.Match() function returns a Match object with details about the match. The .Success property lets
            // us tell whether a match was found.
            return regex.Match(suppliedPassword).Success;
        }

        public static bool IsTextFieldEmpty(TextBox textBox)
        {
            bool isTextFieldEmpty = textBox.Text.Trim() == string.Empty;
            return isTextFieldEmpty;
        }

        public static bool IsTooLong(TextBox textBox, int maxCharacters)
        {
            if (textBox.Text.Length > maxCharacters) 
            {
                return true;
            }
            return false;
        }

        public static void CheckInput(TextBox txt, Label lbl, int maxChars)
        {
            lbl.Text = "";
            if (IsTextFieldEmpty(txt))
            {
                lbl.Text = "Error: Empty";
            }
            else if (IsTooLong(txt, maxChars))
            {
                lbl.Text = "Error: Too long";
            }
        }

        public static bool DoesTextContentMatch(string str1, string str2)
        {
            return str1.Equals(str2);
        }

        public static bool ItemInDGVSelected(DataGridView dgv)
        {
            return (dgv.SelectedRows.Count == 1) ? true : false;
        }

        public static bool ItemInListBoxSelected(ListBox lstBx)
        {
            return (lstBx.SelectedIndex > -1) ? true : false; 
        }
    }
}

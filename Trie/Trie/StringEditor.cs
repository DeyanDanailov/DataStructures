using Magnum.Collections;
using System;
using System.Collections.Generic;

namespace Trie
{
    class StringEditor : ITextEditor
    {
        private Trie<BigList<char>> usersStrings;
        private Trie<Stack<string>> usersStack;
        public StringEditor()
        {
            usersStrings = new Trie<BigList<char>>();
            usersStack = new Trie<Stack<string>>();
        }
        public void Clear(string username)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }
            this.usersStack
                .GetValue(username)
                .Push(String.Join("", usersStrings.GetValue(username)));

            this.usersStrings.Insert(username, new BigList<char>());
        }

        public void Delete(string username, int startIndex, int length)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }
            this.usersStack
                .GetValue(username)
                .Push(String.Join("", usersStrings.GetValue(username)));

            var userString = this.usersStrings.GetValue(username);
            userString.RemoveRange(startIndex, length);
        }

        public void Insert(string username, int index, string str)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }
            this.usersStack
                .GetValue(username)
                .Push(String.Join("", usersStrings.GetValue(username)));

            var userString = this.usersStrings.GetValue(username);
            userString.InsertRange(index, str);
        }

        public int Length(string username)
        {
            return this.usersStrings.GetValue(username).Count;
        }

        public void Login(string username)
        {
            this.usersStrings.Insert(username, new BigList<char>());
            this.usersStack.Insert(username, new Stack<string>());
        }

        public void Logout(string username)
        {
            this.usersStrings.Delete(username);
            this.usersStack.Delete(username);
        }

        public void Prepend(string username, string str)
        {
            if (!this.usersStrings.Contains(username))
            {
                return ;
            }
            this.usersStack
                .GetValue(username)
                .Push(String.Join("", this.usersStrings.GetValue(username)));

            this.usersStrings
                .GetValue(username)
                .AddRangeToFront(str);
        }

        public string Print(string username)
        {
            if (!this.usersStrings.Contains(username))
            {
                return String.Empty;
            }
            return String.Join("", this.usersStrings.GetValue(username));
        }

        public void Substring(string username, int startIndex, int length)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }
            var userString = this.usersStrings.GetValue(username);
            this.usersStack
                .GetValue(username)
                .Push(String.Join("", this.usersStrings.GetValue(username)));
            var newString = userString.GetRange(startIndex, length);

            this.usersStrings.Insert(username, new BigList<char>(newString));
        }

        public void Undo(string username)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }
            //var userString = this.usersStrings.GetValue(username);
            var userHistory = this.usersStack.GetValue(username);
            if (userHistory.Count == 0)
            {
                return;
            }
            var lastUserString = userHistory.Pop();
            //userHistory.Push(String.Join("", userString)); This undoes the Undo command!!!

            this.usersStrings.Insert(username, new BigList<char>(lastUserString));
        }

        public IEnumerable<string> Users(string prefix = "")
        {
            return this.usersStrings.GetByPrefix(prefix);
        }
    }
}

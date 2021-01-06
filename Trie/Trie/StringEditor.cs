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
            throw new NotImplementedException();
        }

        public void Delete(string username, int startIndex, int length)
        {
            throw new NotImplementedException();
        }

        public void Insert(string username, int index, string str)
        {
            throw new NotImplementedException();
        }

        public int Length(string username)
        {
            throw new NotImplementedException();
        }

        public void Login(string username)
        {
            this.usersStrings.Insert(username, new BigList<char>());
            this.usersStack.Insert(username, new Stack<string>());
        }

        public void Logout(string username)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Undo(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Users(string prefix = "")
        {
            throw new NotImplementedException();
        }
    }
}

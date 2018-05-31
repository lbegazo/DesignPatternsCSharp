using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPattern
{
    public class Builder
    {

    }

    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        public const int indentSize = 2;

        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            if (!String.IsNullOrWhiteSpace(name))
                Name = name;
            if (!String.IsNullOrWhiteSpace(text))
                Text = text;
        }

        private string ToStringImplentation(int indent)
        {
            var sb = new StringBuilder();
            var i = new String(' ', indent * indentSize);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImplentation(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.ToStringImplentation(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement _root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            _root.Name = rootName;
        }

        public HtmlElement AddChild(string childName, string childText)
        {
            return AddChild(childName, childText, _root);
        }

        public HtmlElement AddChild(string childName, string childText, HtmlElement root)
        {
            HtmlElement e = new HtmlElement(childName, childText);

            if (root == null)
                throw new ArgumentNullException(nameof(root));

            root.Elements.Add(e);
            return e;
        }

        public override string ToString()
        {
            return _root.ToString();
        }

        public void Clear()
        {
            _root = new HtmlElement { Name = rootName };
        }
    }
}

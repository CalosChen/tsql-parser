using System;
using System.Text;

namespace TSQL.Tokens
{
	public abstract class TSQLToken
	{
		internal protected TSQLToken(
			int beginPosition,
			string text)
		{
			BeginPosition = beginPosition;
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			Text = text;
		}

		public int BeginPosition
		{
			get;
			private set;
		}

		public int EndPosition
		{
			get
			{
				return BeginPosition + Length - 1;
			}
		}

		public int Length
		{
			get
			{
				return Text.Length;
			}
		}

		public string Text
		{
			get;
			private set;
		}

		public abstract TSQLTokenType Type
		{
			get;
		}

		public abstract bool IsComplete
		{
			get;
		}

		public override string ToString()
		{
			return $"[Type: {Type}; Text: \"{ToLiteral(Text)}\"; BeginPosition: {BeginPosition: #,##0}; Length: {Length: #,##0}]";
		}

		// https://stackoverflow.com/a/14087738
		private static string ToLiteral(string input)
		{
			StringBuilder literal = new StringBuilder(input.Length);
			foreach (var c in input)
			{
				switch (c)
				{
					case '\'': literal.Append(@"\'"); break;
					case '\"': literal.Append("\\\""); break;
					case '\\': literal.Append(@"\\"); break;
					case '\0': literal.Append(@"\0"); break;
					case '\a': literal.Append(@"\a"); break;
					case '\b': literal.Append(@"\b"); break;
					case '\f': literal.Append(@"\f"); break;
					case '\n': literal.Append(@"\n"); break;
					case '\r': literal.Append(@"\r"); break;
					case '\t': literal.Append(@"\t"); break;
					case '\v': literal.Append(@"\v"); break;
					default:
						// ASCII printable character
						if (c >= 0x20 && c <= 0x7e)
						{
							literal.Append(c);
							// As UTF16 escaped character
						}
						else
						{
							literal.Append(@"\u");
							literal.Append(((int)c).ToString("x4"));
						}
						break;
				}
			}
			return literal.ToString();
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLBinaryLiteral"/>.
		/// </summary>
		public TSQLBinaryLiteral AsBinaryLiteral
		{
			get
			{
				return this as TSQLBinaryLiteral;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLCharacter"/>.
		/// </summary>
		public TSQLCharacter AsCharacter
		{
			get
			{
				return this as TSQLCharacter;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLComment"/>.
		/// </summary>
		public TSQLComment AsComment
		{
			get
			{
				return this as TSQLComment;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLIdentifier"/>.
		/// </summary>
		public TSQLIdentifier AsIdentifier
		{
			get
			{
				return this as TSQLIdentifier;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLSystemIdentifier"/>.
		/// </summary>
		public TSQLSystemIdentifier AsSystemIdentifier
		{
			get
			{
				return this as TSQLSystemIdentifier;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLKeyword"/>.
		/// </summary>
		public TSQLKeyword AsKeyword
		{
			get
			{
				return this as TSQLKeyword;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLLiteral"/>.
		/// </summary>
		public TSQLLiteral AsLiteral
		{
			get
			{
				return this as TSQLLiteral;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLMultilineComment"/>.
		/// </summary>
		public TSQLMultilineComment AsMultilineComment
		{
			get
			{
				return this as TSQLMultilineComment;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLNumericLiteral"/>.
		/// </summary>
		public TSQLNumericLiteral AsNumericLiteral
		{
			get
			{
				return this as TSQLNumericLiteral;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLOperator"/>.
		/// </summary>
		public TSQLOperator AsOperator
		{
			get
			{
				return this as TSQLOperator;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLSingleLineComment"/>.
		/// </summary>
		public TSQLSingleLineComment AsSingleLineComment
		{
			get
			{
				return this as TSQLSingleLineComment;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLStringLiteral"/>.
		/// </summary>
		public TSQLStringLiteral AsStringLiteral
		{
			get
			{
				return this as TSQLStringLiteral;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLVariable"/>.
		/// </summary>
		public TSQLVariable AsVariable
		{
			get
			{
				return this as TSQLVariable;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLSystemVariable"/>.
		/// </summary>
		public TSQLSystemVariable AsSystemVariable
		{
			get
			{
				return this as TSQLSystemVariable;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLWhitespace"/>.
		/// </summary>
		public TSQLWhitespace AsWhitespace
		{
			get
			{
				return this as TSQLWhitespace;
			}
		}

		/// <summary>
		///		Fluent convenience shortcut for casting object
		///		as <see cref="TSQL.Tokens.TSQLMoneyLiteral"/>
		/// </summary>
		public TSQLMoneyLiteral AsMoneyLiteral
		{
			get
			{
				return this as TSQLMoneyLiteral;
			}
		}
	}

	public static class TSQLTokenExtensions
	{
		public static bool IsKeyword(this TSQLToken token, TSQLKeywords keyword)
		{
			if (token == null)
			{
				return false;
			}

			if (token.Type != TSQLTokenType.Keyword)
			{
				return false;
			}

			if (token.AsKeyword.Keyword != keyword)
			{
				return false;
			}

			return true;
		}

		public static bool IsCharacter(this TSQLToken token, TSQLCharacters character)
		{
			if (token == null)
			{
				return false;
			}

			if (token.Type != TSQLTokenType.Character)
			{
				return false;
			}

			if (token.AsCharacter.Character != character)
			{
				return false;
			}

			return true;
		}

		public static bool IsWhitespace(this TSQLToken token)
		{
			if (token == null)
			{
				return false;
			}
			else
			{
				return token.Type == TSQLTokenType.Whitespace;
			}
		}

		public static bool IsComment(this TSQLToken token)
		{
			if (token == null)
			{
				return false;
			}
			else
			{
				return token.Type == TSQLTokenType.SingleLineComment ||
					token.Type == TSQLTokenType.MultilineComment ||
					token.Type == TSQLTokenType.IncompleteComment;
			}
		}

		public static bool IsFutureKeyword(this TSQLToken token, TSQLFutureKeywords keyword)
		{
			if (token == null)
			{
				return false;
			}
			else
			{
				return TSQLFutureKeywords.Parse(token.Text) == keyword;
			}
		}
	}
}

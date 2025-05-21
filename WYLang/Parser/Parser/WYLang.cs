
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF = 0, // (EOF)
        SYMBOL_ERROR = 1, // (Error)
        SYMBOL_WHITESPACE = 2, // Whitespace
        SYMBOL_AND = 3, // And
        SYMBOL_ASSIGN = 4, // Assign
        SYMBOL_BEGIN = 5, // Begin
        SYMBOL_CALL = 6, // Call
        SYMBOL_COLON = 7, // Colon
        SYMBOL_COMMA = 8, // Comma
        SYMBOL_DIVIDE = 9, // Divide
        SYMBOL_DO = 10, // Do
        SYMBOL_ELSE = 11, // Else
        SYMBOL_END = 12, // End
        SYMBOL_EQUAL = 13, // Equal
        SYMBOL_FOR = 14, // For
        SYMBOL_FUNCTION = 15, // Function
        SYMBOL_GREATER = 16, // Greater
        SYMBOL_GREATEREQUAL = 17, // GreaterEqual
        SYMBOL_IDENTIFIER = 18, // Identifier
        SYMBOL_IF = 19, // If
        SYMBOL_IN = 20, // In
        SYMBOL_INTEGER = 21, // Integer
        SYMBOL_LESS = 22, // Less
        SYMBOL_LESSEQUAL = 23, // LessEqual
        SYMBOL_LET = 24, // Let
        SYMBOL_LPAREN = 25, // LParen
        SYMBOL_MINUS = 26, // Minus
        SYMBOL_MOD = 27, // Mod
        SYMBOL_NOT = 28, // Not
        SYMBOL_NOTEQUAL = 29, // NotEqual
        SYMBOL_OR = 30, // Or
        SYMBOL_PARAMS = 31, // Params
        SYMBOL_PLUS = 32, // Plus
        SYMBOL_PRINT = 33, // Print
        SYMBOL_RETURN = 34, // Return
        SYMBOL_RPAREN = 35, // RParen
        SYMBOL_SEMICOLON = 36, // Semicolon
        SYMBOL_START = 37, // Start
        SYMBOL_STRINGLITERAL = 38, // StringLiteral
        SYMBOL_THEN = 39, // Then
        SYMBOL_TIMES = 40, // Times
        SYMBOL_WHILE = 41, // While
        SYMBOL_WITH = 42, // With
        SYMBOL_ADD_EXPR = 43, // <add_expr>
        SYMBOL_AND_EXPR = 44, // <and_expr>
        SYMBOL_ARG_LIST = 45, // <arg_list>
        SYMBOL_ASSIGNMENT = 46, // <assignment>
        SYMBOL_COMPARE_EXPR = 47, // <compare_expr>
        SYMBOL_COMPARE_OP = 48, // <compare_op>
        SYMBOL_ELSE_PART = 49, // <else_part>
        SYMBOL_EXPRESSION = 50, // <expression>
        SYMBOL_FACTOR = 51, // <factor>
        SYMBOL_FOR_STATEMENT = 52, // <for_statement>
        SYMBOL_FUNCTION_CALL = 53, // <function_call>
        SYMBOL_FUNCTION_DEF = 54, // <function_def>
        SYMBOL_IF_STATEMENT = 55, // <if_statement>
        SYMBOL_MUL_EXPR = 56, // <mul_expr>
        SYMBOL_NOT_EXPR = 57, // <not_expr>
        SYMBOL_PARAM_LIST = 58, // <param_list>
        SYMBOL_PRINT_STATEMENT = 59, // <print_statement>
        SYMBOL_PROGRAM = 60, // <program>
        SYMBOL_STATEMENT = 61, // <statement>
        SYMBOL_STATEMENT_BLOCK = 62, // <statement_block>
        SYMBOL_STATEMENT_LIST = 63, // <statement_list>
        SYMBOL_UNARY = 64, // <unary>
        SYMBOL_WHILE_STATEMENT = 65  // <while_statement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END = 0, // <program> ::= Start <statement_list> End
        RULE_STATEMENT_LIST = 1, // <statement_list> ::= <statement>
        RULE_STATEMENT_LIST2 = 2, // <statement_list> ::= <statement_list> <statement>
        RULE_STATEMENT = 3, // <statement> ::= <assignment>
        RULE_STATEMENT2 = 4, // <statement> ::= <if_statement>
        RULE_STATEMENT3 = 5, // <statement> ::= <while_statement>
        RULE_STATEMENT4 = 6, // <statement> ::= <for_statement>
        RULE_STATEMENT5 = 7, // <statement> ::= <print_statement>
        RULE_STATEMENT6 = 8, // <statement> ::= <function_def>
        RULE_STATEMENT7 = 9, // <statement> ::= <function_call>
        RULE_ASSIGNMENT_LET_IDENTIFIER_ASSIGN_SEMICOLON = 10, // <assignment> ::= Let Identifier Assign <expression> Semicolon
        RULE_IF_STATEMENT_IF_THEN_COLON = 11, // <if_statement> ::= If <expression> Then Colon <statement_block> <else_part>
        RULE_ELSE_PART = 12, // <else_part> ::= 
        RULE_ELSE_PART_ELSE_COLON = 13, // <else_part> ::= Else Colon <statement_block>
        RULE_WHILE_STATEMENT_WHILE_DO_COLON = 14, // <while_statement> ::= While <expression> Do Colon <statement_block>
        RULE_FOR_STATEMENT_FOR_IDENTIFIER_IN_DO_COLON = 15, // <for_statement> ::= For Identifier In <expression> Do Colon <statement_block>
        RULE_PRINT_STATEMENT_PRINT_SEMICOLON = 16, // <print_statement> ::= Print <expression> Semicolon
        RULE_FUNCTION_DEF_FUNCTION_IDENTIFIER_WITH_COLON_RETURN_SEMICOLON = 17, // <function_def> ::= Function Identifier With <param_list> Colon <statement_block> Return <expression> Semicolon
        RULE_FUNCTION_CALL_CALL_IDENTIFIER_WITH_SEMICOLON = 18, // <function_call> ::= Call Identifier With <arg_list> Semicolon
        RULE_STATEMENT_BLOCK = 19, // <statement_block> ::= <statement>
        RULE_STATEMENT_BLOCK2 = 20, // <statement_block> ::= <statement_block> <statement>
        RULE_EXPRESSION_OR = 21, // <expression> ::= <expression> Or <and_expr>
        RULE_EXPRESSION = 22, // <expression> ::= <and_expr>
        RULE_AND_EXPR_AND = 23, // <and_expr> ::= <and_expr> And <not_expr>
        RULE_AND_EXPR = 24, // <and_expr> ::= <not_expr>
        RULE_NOT_EXPR_NOT = 25, // <not_expr> ::= Not <compare_expr>
        RULE_NOT_EXPR = 26, // <not_expr> ::= <compare_expr>
        RULE_COMPARE_EXPR = 27, // <compare_expr> ::= <add_expr> <compare_op> <add_expr>
        RULE_COMPARE_EXPR2 = 28, // <compare_expr> ::= <add_expr>
        RULE_COMPARE_OP_EQUAL = 29, // <compare_op> ::= Equal
        RULE_COMPARE_OP_NOTEQUAL = 30, // <compare_op> ::= NotEqual
        RULE_COMPARE_OP_LESS = 31, // <compare_op> ::= Less
        RULE_COMPARE_OP_GREATER = 32, // <compare_op> ::= Greater
        RULE_COMPARE_OP_LESSEQUAL = 33, // <compare_op> ::= LessEqual
        RULE_COMPARE_OP_GREATEREQUAL = 34, // <compare_op> ::= GreaterEqual
        RULE_ADD_EXPR_PLUS = 35, // <add_expr> ::= <add_expr> Plus <mul_expr>
        RULE_ADD_EXPR_MINUS = 36, // <add_expr> ::= <add_expr> Minus <mul_expr>
        RULE_ADD_EXPR = 37, // <add_expr> ::= <mul_expr>
        RULE_MUL_EXPR_TIMES = 38, // <mul_expr> ::= <mul_expr> Times <unary>
        RULE_MUL_EXPR_DIVIDE = 39, // <mul_expr> ::= <mul_expr> Divide <unary>
        RULE_MUL_EXPR_MOD = 40, // <mul_expr> ::= <mul_expr> Mod <unary>
        RULE_MUL_EXPR = 41, // <mul_expr> ::= <unary>
        RULE_UNARY_MINUS = 42, // <unary> ::= Minus <unary>
        RULE_UNARY_PLUS = 43, // <unary> ::= Plus <unary>
        RULE_UNARY = 44, // <unary> ::= <factor>
        RULE_FACTOR_LPAREN_RPAREN = 45, // <factor> ::= LParen <expression> RParen
        RULE_FACTOR_IDENTIFIER = 46, // <factor> ::= Identifier
        RULE_FACTOR_INTEGER = 47, // <factor> ::= Integer
        RULE_FACTOR_STRINGLITERAL = 48, // <factor> ::= StringLiteral
        RULE_PARAM_LIST_IDENTIFIER = 49, // <param_list> ::= Identifier
        RULE_PARAM_LIST_IDENTIFIER_COMMA = 50, // <param_list> ::= Identifier Comma <param_list>
        RULE_ARG_LIST = 51, // <arg_list> ::= <expression>
        RULE_ARG_LIST_COMMA = 52  // <arg_list> ::= <expression> Comma <arg_list>
    };
    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox lst2;
        public MyParser(string filename, ListBox lst, ListBox lst2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);

            this.lst = lst;
            this.lst2 = lst2;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead +=  new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

       

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF:
                    //(EOF)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ERROR:
                    //(Error)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE:
                    //Whitespace
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_AND:
                    //And
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN:
                    //Assign
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_BEGIN:
                    //Begin
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_CALL:
                    //Call
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COLON:
                    //Colon
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COMMA:
                    //Comma
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DIVIDE:
                    //Divide
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DO:
                    //Do
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ELSE:
                    //Else
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_END:
                    //End
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EQUAL:
                    //Equal
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR:
                    //For
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION:
                    //Function
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GREATER:
                    //Greater
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GREATEREQUAL:
                    //GreaterEqual
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER:
                    //Identifier
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF:
                    //If
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IN:
                    //In
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_INTEGER:
                    //Integer
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LESS:
                    //Less
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LESSEQUAL:
                    //LessEqual
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LET:
                    //Let
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LPAREN:
                    //LParen
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUS:
                    //Minus
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MOD:
                    //Mod
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NOT:
                    //Not
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NOTEQUAL:
                    //NotEqual
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_OR:
                    //Or
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PARAMS:
                    //Params
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PLUS:
                    //Plus
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PRINT:
                    //Print
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RETURN:
                    //Return
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RPAREN:
                    //RParen
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SEMICOLON:
                    //Semicolon
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_START:
                    //Start
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL:
                    //StringLiteral
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_THEN:
                    //Then
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TIMES:
                    //Times
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE:
                    //While
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WITH:
                    //With
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ADD_EXPR:
                    //<add_expr>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_AND_EXPR:
                    //<and_expr>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ARG_LIST:
                    //<arg_list>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT:
                    //<assignment>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COMPARE_EXPR:
                    //<compare_expr>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COMPARE_OP:
                    //<compare_op>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ELSE_PART:
                    //<else_part>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION:
                    //<expression>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FACTOR:
                    //<factor>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR_STATEMENT:
                    //<for_statement>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_CALL:
                    //<function_call>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_DEF:
                    //<function_def>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF_STATEMENT:
                    //<if_statement>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MUL_EXPR:
                    //<mul_expr>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NOT_EXPR:
                    //<not_expr>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PARAM_LIST:
                    //<param_list>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STATEMENT:
                    //<print_statement>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM:
                    //<program>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT:
                    //<statement>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT_BLOCK:
                    //<statement_block>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT_LIST:
                    //<statement_list>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_UNARY:
                    //<unary>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STATEMENT:
                    //<while_statement>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END:
                    //<program> ::= Start <statement_list> End
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST:
                    //<statement_list> ::= <statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST2:
                    //<statement_list> ::= <statement_list> <statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT:
                    //<statement> ::= <assignment>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT2:
                    //<statement> ::= <if_statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT3:
                    //<statement> ::= <while_statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT4:
                    //<statement> ::= <for_statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT5:
                    //<statement> ::= <print_statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT6:
                    //<statement> ::= <function_def>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT7:
                    //<statement> ::= <function_call>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_LET_IDENTIFIER_ASSIGN_SEMICOLON:
                    //<assignment> ::= Let Identifier Assign <expression> Semicolon
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_THEN_COLON:
                    //<if_statement> ::= If <expression> Then Colon <statement_block> <else_part>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ELSE_PART:
                    //<else_part> ::= 
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ELSE_PART_ELSE_COLON:
                    //<else_part> ::= Else Colon <statement_block>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_WHILE_STATEMENT_WHILE_DO_COLON:
                    //<while_statement> ::= While <expression> Do Colon <statement_block>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FOR_STATEMENT_FOR_IDENTIFIER_IN_DO_COLON:
                    //<for_statement> ::= For Identifier In <expression> Do Colon <statement_block>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PRINT_STATEMENT_PRINT_SEMICOLON:
                    //<print_statement> ::= Print <expression> Semicolon
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FUNCTION_DEF_FUNCTION_IDENTIFIER_WITH_COLON_RETURN_SEMICOLON:
                    //<function_def> ::= Function Identifier With <param_list> Colon <statement_block> Return <expression> Semicolon
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FUNCTION_CALL_CALL_IDENTIFIER_WITH_SEMICOLON:
                    //<function_call> ::= Call Identifier With <arg_list> Semicolon
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT_BLOCK:
                    //<statement_block> ::= <statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT_BLOCK2:
                    //<statement_block> ::= <statement_block> <statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION_OR:
                    //<expression> ::= <expression> Or <and_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION:
                    //<expression> ::= <and_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_AND_EXPR_AND:
                    //<and_expr> ::= <and_expr> And <not_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_AND_EXPR:
                    //<and_expr> ::= <not_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NOT_EXPR_NOT:
                    //<not_expr> ::= Not <compare_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NOT_EXPR:
                    //<not_expr> ::= <compare_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPARE_EXPR:
                    //<compare_expr> ::= <add_expr> <compare_op> <add_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPARE_EXPR2:
                    //<compare_expr> ::= <add_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPARE_OP_EQUAL:
                    //<compare_op> ::= Equal
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPARE_OP_NOTEQUAL:
                    //<compare_op> ::= NotEqual
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPARE_OP_LESS:
                    //<compare_op> ::= Less
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPARE_OP_GREATER:
                    //<compare_op> ::= Greater
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPARE_OP_LESSEQUAL:
                    //<compare_op> ::= LessEqual
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COMPARE_OP_GREATEREQUAL:
                    //<compare_op> ::= GreaterEqual
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADD_EXPR_PLUS:
                    //<add_expr> ::= <add_expr> Plus <mul_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADD_EXPR_MINUS:
                    //<add_expr> ::= <add_expr> Minus <mul_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADD_EXPR:
                    //<add_expr> ::= <mul_expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MUL_EXPR_TIMES:
                    //<mul_expr> ::= <mul_expr> Times <unary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MUL_EXPR_DIVIDE:
                    //<mul_expr> ::= <mul_expr> Divide <unary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MUL_EXPR_MOD:
                    //<mul_expr> ::= <mul_expr> Mod <unary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MUL_EXPR:
                    //<mul_expr> ::= <unary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_UNARY_MINUS:
                    //<unary> ::= Minus <unary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_UNARY_PLUS:
                    //<unary> ::= Plus <unary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_UNARY:
                    //<unary> ::= <factor>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN:
                    //<factor> ::= LParen <expression> RParen
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FACTOR_IDENTIFIER:
                    //<factor> ::= Identifier
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FACTOR_INTEGER:
                    //<factor> ::= Integer
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FACTOR_STRINGLITERAL:
                    //<factor> ::= StringLiteral
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PARAM_LIST_IDENTIFIER:
                    //<param_list> ::= Identifier
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PARAM_LIST_IDENTIFIER_COMMA:
                    //<param_list> ::= Identifier Comma <param_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ARG_LIST:
                    //<arg_list> ::= <expression>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ARG_LIST_COMMA:
                    //<arg_list> ::= <expression> Comma <arg_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'";
            string message3 = "At Line: " + args.UnexpectedToken.Location.LineNr.ToString();
            string message2 = "Expected: " + args.ExpectedTokens.ToString();

            lst.Items.Add(message);
            lst.Items.Add(message2);
            lst.Items.Add(message3);
            //todo: Report message to UI?
        }
        private void TokenReadEvent(LALRParser pr, TokenReadEventArgs args)
        {
            string info = args.Token.Text + ": \t" + (SymbolConstants)args.Token.Symbol.Id;
            lst2.Items.Add(info);
        }

    }
}

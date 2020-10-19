grammar Lab1; 


/*
* Parser Rules
*/


compileUnit : expression EOF;


expression :
	LPAREN expression RPAREN												#ParenthesizedExpr
	| expression EXPONENT expression										#ExponentialExpr
	| expression operatorToken=(MULTIPLY | DIVIDE | MOD | DIV) expression	#MultiplicativeExpr
	| expression operatorToken=(ADD | SUBTRACT) expression					#AdditiveExpr
	| expression operatorToken=(GT | GE | LT | LE) expression				#RelationalExpr
	| expression operatorToken=(EQ | NE)									#EqualityExpr
	| IDENTIFIER															#IdentifierExpr
	| NUMBER																#NumberExpr
	;

/*
 * Lexer Rules 
 */

NUMBER : INT ('.'INT)?;
IDENTIFIER : [a-zA-Z]+[1-9][0-9]+;

INT : ('0'..'9')+;

EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';
MOD: 'mod';
DIV: 'div';
GT : '>';
GE : '>=';
LT : '<';
LE : '<=';
EQ : '=';
NE : '<>';

WS : [ \t\r\n] -> channel(HIDDEN);
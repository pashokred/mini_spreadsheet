grammar Lab1; 


/*
* Parser Rules
*/


compileUnit : expression EOF;


expression :
	LPAREN expression RPAREN #ParenthesizedExpr
	| expression MOD expression #ModExpr
	| expression DIV expression #DivExpr
	| expression EXPONENT expression #ExponentialExpr
	| expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
	| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
	| NUMBER #NumberExpr
	| IDENTIFIER #IdentifierExpr
	| expression operatorToken=(GT | GE | LT | LE | EQ) expression #ComparisonExpr
	;
	
comp_operator : GT
			  | GE
			  | LT
			  | LE
			  | EQ
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

WS : [ \t\r\n] -> channel(HIDDEN);
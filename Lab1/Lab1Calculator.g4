grammar LabCalculator; 2


/*
* Parser Rules
*/


compileUnit : expression EOF;


expression :
	LPAREN expression RPAREN #ParenthesizedExpr
	|expression EXPONENT expression #ExponentialExpr
	| expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
	| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
	| NUMBER #NumberExpr
	| IDENTIFIER #IdentifierExpr
	;
/*
 * Lexer Rules 
 */

NUMBER : INT ('.' INT)?;
IDENTIFIER : [a-zA-Z]+[1-9][0-9]+;

INT : (&#39;0&#39;..&#39;9&#39;)+;

EXPONENT : &#39;^&#39;;
MULTIPLY : &#39;*&#39;;
DIVIDE : &#39;/&#39;;
SUBTRACT : &#39;-&#39;;
ADD : &#39;+&#39;;
LPAREN : &#39;(&#39;;
RPAREN : &#39;)&#39;;
WS : [ \t\r\n] -&gt; channel(HIDDEN);
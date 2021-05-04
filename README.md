

# Mini spreadsheet
> Windows Forms Application C#

This is pretty spreadsheet created in Windows Forms that can help you make basic operations with cells and values. 

### Used:

* ANTLR4 for parsing expressions
* Windows Forms for GUI


## Screenshot of operation

![Table Screenshot](https://github.com/pashokred/mini_spreadsheet/blob/master/img/TableScreenshot.png)

## Developing


```shell
git clone https://github.com/pashokred/mini_spreadsheet.git
```

And open it in IDE with .NET Core 3.1 and Windows Forms support

## Features   

There is all the bells and whistles this project can perform:
* The main functionality is to easy calculate expressions with double values and cell initializers

    In this form you can use next operations: 

      * Arithmetic operations

        +, -, *, / (binar operations)
        ^ (put number in the power)
        
        mod (modulo operation or operation %) - returns the remainder or signed remainder of a division, after one number is divided by another)
        
        div (integer division) - is division in which the fractional part (remainder) is discarded is called integer division and is sometimes denoted

      * Logical operations:

        =, <, >
        <=, >=, <>
        (returns '1' if true and '0' if false)

* You can also do operations with cell identifiers:

* Create table by your own size, Add/Delete last rows and columns

* If you get really randy, you can even export this table in .xlsx format or import in table from files with extentions .xls, .xlsx, Excel WorkBook, Excel Workbook 97-2003.

## Configuration


#### Argument 1 

##### Returns result of Logical operation

Type: `Double|String`<br>
Return: `Double`  
Default: `0`

A2 = `45`;
H4 = `7`;
F3 = `26`;
G3 = F3;
B1 = `45`;
E5 = `16`;




Example:
```bash
((A2+50) - H4*10) mod F3 + G3 div B1 > (E5/3)^4  # Prints 0
```

#### Argument 2 

##### Returns result of Arithmetical operation

Type: `Double|String`<br>
Return: `Double`  
Default: `0`

A2 = `45`;
F3 = `26`;
B1 = `45`;
E5 = `16`;


Example:
```bash
(A2+45) / F3 mod E5 - 50 mod B1  # Prints -1.5384...
```



## Contributing

If you'd like to contribute, please fork the repository and use a feature
branch. Pull requests are warmly welcome!

## Links

- Repository: https://github.com/pashokred/mini_spreadsheet
- Issue tracker: https://github.com/pashokred/mini_spreadsheet/issues
  - In case of sensitive bugs like security vulnerabilities, please contact
    redkopavli@gmail.com directly instead of using issue tracker. We value your effort to improve the security and privacy of this project!
- Related projects:
  - Battleship: https://github.com/your/other-project/


## Licensing

The code in this project is licensed under MIT license.

## Use-case diagram:

![Use-case diagram](https://github.com/pashokred/mini_spreadsheet/blob/master/img/UseCaseDiagram.png)

## Class diagram:

![Class diagram](https://github.com/pashokred/mini_spreadsheet/blob/master/img/ClassDiagram.png)

## Sequence diagram:

![Sequence diagram](https://github.com/pashokred/mini_spreadsheet/blob/master/img/SequenceDiagram.png)


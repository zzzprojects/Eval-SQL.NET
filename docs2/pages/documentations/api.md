# API

## Overview

Let's take a very short overview with the API


```csharp
SELECT SQLNET::New('x+y').ValueInt('x', 1).ValueInt('y', 2).EvalInt() as Result
```
{% include  component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/1123' %}


 - **SQLNET:** A CLR Type created by Eval SQL.NET library
 - **"::":** This is how you call static method in SQL CLR
 - **New:** A static method which creates a new instance of SQLNET Type
 - **ValueInt:** Sets a int value for a specific parameter name used in the expression
 - **EvalInt:** Evaluates the expression and return a result of type INT

<div class="card-group">
	
		<div class="card">
			<div class="card-header">
				<h2>Methods</h2>
			</div>
			
			<div class="card-body">

<div markdown="1">

 - [Eval](/eval)
 - [Value](/value)
 - [Options](/options)
 - [Configuration](/configuration)

</div>
			</div>
		</div>
</div>

<style>
.card-group .card-body {
	padding-top: 20px;
}

.card-group .card-body li {
	padding-top: 5px;
}
</style>

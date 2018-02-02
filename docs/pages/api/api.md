---
permalink: api
---

## Overview

Let take a very short overview with the API

{% include template-example.html %} 
{% highlight csharp %}
SELECT SQLNET::New('x+y').ValueInt('x', 1).ValueInt('y', 2).EvalInt() as Result
{% endhighlight %}
{% include  component-try-it.html href='http://sqlfiddle.com/#!18/9eecb/984' %}

 - **SQLNET:** A CLR Type created by Eval SQL.NET library
 - **"::":** This is how you call static method in SQL CLR
 - **New:** A static method which create a new instance of SQLNET Type
 - **ValueInt:** Set a int value for a specific parameter name used in the expression
 - **EvalInt:** Evaluate the expression and return a result of type INT

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

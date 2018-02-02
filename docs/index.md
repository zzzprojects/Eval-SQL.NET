---
layout: default
permalink: index
---

<!-- hero !-->
<div class="layout-angle">
	<div class="top-triangle wow slideInRight" data-wow-duration="1.5s"></div>
	<div class="layout-angle-inner">
<div class="hero">
	<div class="container">
		<div class="row">
		
			<div class="col-lg-5 hero-header">
			
				<h1>
					<div class="display-4">Eval SQL.NET</div>
				</h1>
				
				<div class="wow zoomIn">
					<a class="btn btn-xl btn-z" href="{{ site.github.url }}/download"
							onclick="ga('send', 'event', { eventAction: 'download-hero'});">
						<i class="fa fa-cloud-download" aria-hidden="true"></i>
						NuGet Download
						<i class="fa fa-angle-right"></i>
					</a>
				</div>
				
				<div class="download-count">
					<div class="item-text">Download Count:</div>
					<div class="item-image wow lightSpeedIn"><img src="https://zzzprojects.github.io/images/nuget/ef6-full-version-big-d.svg" /></div>
				</div>

				
			</div>
			
			<div class="col-lg-7 hero-examples">
			
				<div class="row hero-examples-1">
				
				
					<div class="col-lg-3 wow slideInUp"> 
						<h5 class="wow rollIn">EASY TO<br />USE</h5>
						<div class="hero-arrow hero-arrow-ltr">
							<img src="images/arrow-down1.png">
						</div>
					</div>

					<div class="col-lg-9 wow slideInRight">
						<div class="card card-code card-code-dark-inverse">
							<div class="card-header">Extend SQL with Dynamic Evaluation</div>
							<div class="card-body">
{% highlight csharp %}
-- Evaluate dynamically expression in T-SQL
DECLARE @tableFormula TABLE (
   Formula VARCHAR(255), X INT, Y INT, Z INT
)

INSERT INTO @tableFormula VALUES ('x+y*z', 1, 2, 3 ), 
                                ('(x+y)*z', 1, 2, 3 )
-- SELECT 7
-- SELECT 9
SELECT SQLNET::New(Formula)
              .ValueInt('x', X)
              .ValueInt('y', Y)
              .ValueInt('z', Z).EvalInt() as Result
FROM @tableFormula
{% endhighlight %}
{% include  component-try-it.html href='http://sqlfiddle.com/#!18/19808/2' %}
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="row hero-examples-2 wow slideInUp">
                <h2>
					<div class="display-6">Extend SQL with Dynamic Evaluation at Runtime Using C# Expression.</div>
				</h2>			
		    </div>
		</div>
	</div>	
</div>
	</div>
	<div class="bottom-triangle-outer">
		<div class="bottom-triangle wow slideInLeft" data-wow-duration="1.5s"></div>
	</div>
</div>
<style>
.hero {
	background: transparent;
}
</style>

<!-- featured !-->
<div class="featured">
	<div class="container">
	
		<!-- SQL Eval Function like JavaScript !-->
		<h2 class="wow slideInUp">SQL Eval Function like JavaScript</h2>
		<div class="row">
            <div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">Avoid using slow user-defined function (UDF) and table-valued function (TVF) and dramatically improve query performance with Eval SQL.NET.</p>
				<ul>
					<li>Execute SQL <span class="text-z">3-20x faster</span> than UDF and TVF</li>
					<li>Evaluate an expression more than <span class="text-z">ONE MILLION</span> times under a second</li>
					<li>Evaluate expression using C# Syntax</li>
				</ul>
			</div>
			<div class="col-lg-7 right wow slideInRight">
				<table>
					<thead>
						<tr>
							<th>Methods</th>
							<th>1,000 Rows</th>
							<th>10,000 Rows</th>
							<th>100,000 Rows</th>
                            <th>1,000,000 Rows</th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<th>Eval SQL.NET</th>
							<td>4 ms</td>
							<td>13 ms</td>
							<td>160 ms</td>
                            <td>1,650 ms</td>
						</tr>
						<tr>
							<th>fn_split (TVF)</th>
							<td>100 ms</td>
							<td>625 ms</td>
							<td>5,500 ms</td>
                            <td>55,000 ms</td>
						</tr>
					</tbody>
				</table>

				<p class="text-muted">* Benchmark to split a text with a delimiter</p>
			</div>
		</div>
	</div>
</div>

<div class="testimonials">
{% include layout-angle-begin.html %}
	<div class="container">
		<h2>Amazing <span class="text-z">performance</span>, outstanding <span class="text-z">support</span>!</h2>
		
		<blockquote class="blockquote text-center wow slideInLeft">
			<p class="mb-0">We were very, very pleased with the customer support. There was no question, problem or wish that was not answered AND solved within days! We think that’s very unique!</p>
			<footer class="blockquote-footer">Klemens Stelzmüller, <a href="http://www.beka-software.at/" target="_blank">Beka-software</a></footer>
		</blockquote>
		<blockquote class="blockquote text-center wow slideInRight">
			<p class="mb-0">I’d definitely recommend it as it is a great product with a great performance and reliability.</p>
			<footer class="blockquote-footer">Eric Rey, <a href="http://www.transturcarrental.com/" target="_blank">Transtur</a></footer>
		</blockquote>

		<div class="more">
			<a href="http://www.zzzprojects.com/testimonials/" target="_blank" class="btn btn-lg btn-z" role="button"
					onclick="ga('send', 'event', { eventAction: 'testimonials'});">
				<i class="fa fa-comments"></i>&nbsp;
				Read More Testimonials
			</a>
		</div>
	</div>
{% include layout-angle-end.html %}
</div>


<!-- features !-->
<div class="features">

	<div class="container">
		
		<!-- Evaluate dynamic arithmetic/math expression in SQL !-->
		<h2 class="wow slideInUp">Evaluate dynamic arithmetic expression in SQL</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">Make the impossible now possible. Evaluate C# expression in SQL to overcome limitations.</p>
				<ul>
					<li>Allow trusted users to create report field and filter</li>
					<li>Consume Web Service</li>
					<li>Replace text in template with String Interpolation</li>
				</ul>
				<div class="more-info">
					<a href="{{ site.github.url }}/arithmetic-expressions" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Dynamic Expression Example</div>
					<div class="card-body">
{% highlight csharp %}
// Easy to use
-- CREATE test
DECLARE @table TABLE ( X INT, Y INT, Z INT )
INSERT  INTO @table VALUES  ( 2, 4, 6 ),  ( 3, 5, 7 ), ( 4, 6, 8 )

-- Result: 14, 22, 32
DECLARE @sqlnet SQLNET = SQLNET::New('x*y+z')
SELECT  @sqlnet.ValueInt('x', X)
               .ValueInt('y', Y)
               .ValueInt('z', Z)
               .EvalInt() as Result
FROM    @table			
{% endhighlight %}
{% include  component-try-it.html href='http://sqlfiddle.com/#!18/19808/2' %}
					</div>
				</div>
			</div>
		</div>

		<hr class="m-y-md" />
		
		<!-- Split text with delimiter !-->
		<h2 class="wow slideInUp">Split text with delimiter</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">Improve <span class="text-z">performance</span> and <span class="text-z">capability</span> for splitting text with an easy to use split function and LINQ expressions.</p>
				<ul>
					<li>Split text with multiple delimiters</li>
					<li>Split text using a regular expression</li>
					<li>Include row index</li>
				</ul>
				<div class="more-info">
					<a href="{{ site.github.url }}/split-text" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Split Text Example</div>
					<div class="card-body">
{% highlight csharp %}

-- CREATE test
DECLARE @t TABLE (Id INT , Input VARCHAR(MAX))
INSERT  INTO @t VALUES  ( 1, '1, 2, 3; 4; 5' ), ( 2, '6;7,8;9,10' )

-- SPLIT with many delimiters: ',' and ';'
DECLARE @sqlnet SQLNET = SQLNET::New('Regex.Split(input, ",|;")')

SELECT  *
FROM    @t AS A
        CROSS APPLY ( SELECT    *
                      FROM      dbo.SQLNET_EvalTVF_1(@sqlnet.ValueString('input', Input))
                    ) AS B
{% endhighlight %}	
{% include  component-try-it.html href='http://sqlfiddle.com/#!18/b75fc/4' %}
					</div>
				</div>
			</div>
		</div>
		
		<hr class="m-y-md" />
		
		<!-- Use regular expression in SQL Server !-->
		<h2 class="wow slideInUp">Use regular expression in SQL Server</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">Use Regex <span class="text-z">flexibility</span> to overcome "LIKE" and "PATHINDEX" limitations.</p>
				<ul>
					<li>IsMatch</li>
					<li>Match</li>
					<li>Matches</li>
					<li>Replace</li>
					<li>Split</li>
				</ul>
				<div class="more-info">
					<a href="{{ site.github.url }}/regular-expressions" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Regular Expression Example</div>
					<div class="card-body">
{% highlight csharp %}
DECLARE @customer TABLE ( Email VARCHAR(255) )

INSERT  INTO @customer
VALUES  ( 'info@zzzprojects.com' ),
        ( 'invalid.com' ),
        ( 'sales@zzzprojects.com' )

DECLARE @valid_email SQLNET = SQLNET::New('Regex.IsMatch(email, 
@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")')

-- SELECT 'invalid.com'
SELECT * FROM @customer WHERE @valid_email.ValueString('email', Email).EvalBit() = 0
{% endhighlight %}	
{% include  component-try-it.html href='http://sqlfiddle.com/#!18/7cefe/1' %}
					</div>
				</div>
			</div>
		</div>

       <hr class="m-y-md" />
		
		<!-- Replace xp_cmdshell with restrictive alternative !-->
		<h2 class="wow slideInUp">Replace xp_cmdshell with restrictive alternative</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">void enabling xp_cmdshell and compromising your SQL Server and use instead a more <span class="text-z">restrictive</span> solution.</p>
				<ul>
					<li>Impersonate Context</li>
					<li>Improve maintainability</li>
					<li>Improve readability</li>
					<li>Improve security</li>
				</ul>
				<div class="more-info">
					<a href="{{ site.github.url }}/sql-server-file-operation" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Example</div>
					<div class="card-body">
{% highlight csharp %}
-- REQUIRE EXTERNAL_ACCESS permission
DECLARE @sqlnet SQLNET = SQLNET::New('
string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

var dir = new DirectoryInfo(path);
return dir.GetFiles("*.*")
          .Select(x => new { x.FullName, FileContent = File.ReadAllText(x.FullName) })
          .OrderBy(x => x.FullName)')
          .Impersonate()

-- SELECT FullName, FileContext FROM DesktopFiles ORDER BY Fullname
EXEC dbo.SQLNET_EvalResultSet @sqlnet
{% endhighlight %}	
					</div>
				</div>
			</div>
		</div>
		
		<!-- more-feature !-->
		<div class="more">
			<a href="{{ site.github.url }}/tutorials" class="btn btn-z btn-xl" role="button">
				<i class="fa fa-book"></i>&nbsp;Read Tutorials
			</a>
		</div>
		
	</div>
</div>

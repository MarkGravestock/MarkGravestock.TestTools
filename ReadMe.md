### Test Tools

This project includes samples using testing tools that I've used and/or are of interest. I also may include samples of features that I've used
as a reminder

#### Test Execution

These libraries help are primarily of interest as [Test Runners](http://xunitpatterns.com/Test%20Runner.html)

- [XUnit](https://xunit.github.io/). Default choice as a unit test runner framework. Will generally use with another assertion library, as the supplied assertion syntax is not to
my taste (mainly remembering the order of expect/actual and no Assert.That). Well supported from a tooling perspective. 
- [Fixie](http://fixie.github.io/). Customisable testing framework, which allows creation of custom test execution conventions (e.g. allowing NUnit style [Shared Fixture](http://xunitpatterns.com/Shared%20Fixture.html) tests), notably ships with no assertion framework to focus on the
reponsibility of test execution. Main drawback is no support for JetBrains test runner.

#### Assertion

These libraries help with [State Verification](http://xunitpatterns.com/State%20Verification.html), working with [Direct Inputs](http://xunitpatterns.com/direct%20input.html) and [Direct Outputs](http://xunitpatterns.com/direct%20output.html) of the SUT.

My preference is for a library that makes assertions expressive and provides good diagnostics. I quite like a fluent API that is discoverable.

- [Shouldly](https://shouldly.readthedocs.io/en/latest/index.html). Present default choice, not very fluent although there is a more fluent version, hence revisting
by looking at below.
- [FluentAssertions](https://fluentassertions.com/). Interesting because it now appears to have diagnostics as good as Shouldy, documentation seems better and
also ComparableTo is interesting as a feature to support asserting whether 2 instances have the same properties 
(i.e. making asserting a single condition simpler moving from [Procedural State Verification](http://xunitpatterns.com/State%20Verification.html#Procedural%20State%20Verification) to [Expected Object](http://xunitpatterns.com/State%20Verification.html#Expected%20Object) where there is no requirement
for the SUT to support equality). 

#### ATDD Tools

[Examples are here](https://github.com/MarkGravestock/SpecByExampleCSharp)




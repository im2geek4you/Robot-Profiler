# Robot-Profiler
Robot Framework execution profiler

This tool can process a output xml file from Robot (or Rebot) execution and show various metrics regarding the execution time spent on each keyword. It will allow
to determine which keywords need to be optimized based on which ones are taking longer or run more often.


## What is the xml format expected from Robot or Rebot?

Robot Profiler expects the xml output from Robot framework execution to have the following format:

	<robot generator="Robot 2.9.2 (Jython 2.7.0 on java1.8.0_71)" generated="20170718 14:34:21.712">
		<suite id="s1" name="Automation">
			<test id="s1-t1" name="Launch Application">
				<kw name="Set Variable" library="BuiltIn">
					(...)
					<status status="PASS" endtime="20170407 19:42:02.368" starttime="20170407 19:42:02.363"/>
				</kw>
				<status status="PASS" endtime="20170407 19:42:58.758" critical="yes" starttime="20170407 19:42:02.334"/>
			</test>
			<status status="PASS" endtime="20170407 19:43:29.287" starttime="20170407 19:41:49.967"/>
		</suite>
	</robot>

In some cases starttime and/or endtime are not available, but elapsedtime is present. This is supported also. 
Robot Profiler has been tested with xml files over 2GB without issues (this is because the xml file is read line by line instead of loading it to memory).

## What information does Robot Profiler provide to you?
Robot profiler shows a list of all distinct Keywords, Tests and Suites exected in a xml file. Per each Keyword, Test or Suite it shows how many executions occured and it's average duration.
The different Keywords, Tests and Suites are colored differently so they are easy to see. You can also search and sort them. 
By selecting and right-clicking a Keyword on the main table with more than one run it is possible to generate a graphic with all executions versus it's duration. This
is very usefull since it shows how some Keywords can start taking longer over the course of the execution of long runs.


Robot Profiles is under development... if you find errors or would like to see some feature, please let me know. 

## Download
In case you don't want to compile your own version of Robot Profiler you can download the compiled version below.

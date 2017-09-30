# Robot-Profiler
Robot Framework execution profiler

This tool can process a output xml file from Robot (or Rebot) execution and show various metrics regarding the execution time spent on each keyword. It will allow
to determine which keywords need to be optimized based on which ones are taking longer or run more often.

![Screenshot01](https://user-images.githubusercontent.com/13609585/29005913-c95aff5e-7add-11e7-91f2-8bc9643bcacb.png)

![Screenshot02](https://user-images.githubusercontent.com/13609585/29005915-c95bec2a-7add-11e7-931f-1ccfa0c977d5.png)

![Screenshot03](https://user-images.githubusercontent.com/13609585/29005914-c95bb2fa-7add-11e7-9087-231bb2519be8.png)

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

## Usage

Use File->Open Robot Output XML from menu and select the xml file from the Robot execution. The file will be analysed and a file with the extension .db and same name 
as the xml will be created to store information processed. You can later open this .db file instead of waiting for the xml to be processed again. Robot profiler also support drag & drop of any of these files.
After this the data will be shown in a table containing all Keywords, Tests and Suited found, their count and average duration. You can sort, search and plot all executions of a selected 
Keyword (if it has more than one execution).

## Download
In case you don't want to compile your own version of Robot Profiler you can download the compiled version below.

![Robot Profiler v0.0.0.5.zip](https://github.com/im2geek4you/Robot-Profiler/files/1346630/Robot.Profiler.v0.0.0.5.zip)

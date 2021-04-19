# HeapDuplicationAnalyser

Small tool to help find duplicated strings in memory dumps. 

If you have many duplicated strings you might considering using String.Intern as an optimization point to save memory.

I created this tool as I am working with big dumps (20 GB in size) and DotMemory is unable to open the dumps due to "Out Of Memory". 

The tool will print the top 100 strings with most duplications.

## Usage Instructions

1. Create a **Full** Process Dump (e.g. in Task Manager, right-click on the process and click **Create Dump File**)
1. Run the tool by executing the command line HeapDuplicationAnalyser.exe <Full path of the Process Dump>

## Sample output

Loading dump

Dump loaded - analyzing

Times duplicated 823435 - value: PROD

Times duplicated 815731 - value: DEV

Times duplicated 781543 - value: SAND

Times duplicated 781504 - value: STAGING

Times duplicated 781501 - value: UN

Times duplicated 677617 - value: Server=localhost\sql;Database=LOCAL;UID=LOCAL;MultipleActiveResultSets=True;

Times duplicated 566714 - value: DK

Times duplicated 554733 - value: US

Times duplicated 553422 - value: GB

Times duplicated 550399 - value: DE

Times duplicated 524179 - value: HR

Times duplicated 480995 - value: 0

Times duplicated 443097 - value: PR

Times duplicated 213066 - value: 1

Times duplicated 134877 - value: 3

Times duplicated 133046 - value: S

Times duplicated 128589 - value: K

Times duplicated 102580 - value: 2

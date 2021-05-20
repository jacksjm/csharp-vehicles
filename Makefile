output: mcs.e mono.e clean
 
mcs.e:
	mcs Program.cs Views/lib/LibLabel.cs Views/lib/LibButon.cs Views/lib/LibText.cs Views/lib/LibNumeric.cs Views/lib/InputBox.cs Views/lib/LibForm.cs Views/lib/LibList.cs Views/VisualCustomer.cs Controllers/* Models/* Repository/*.cs Views/Import.cs -r:System.Windows.Forms.dll,System.Drawing.dll -pkg:dotnet
 
 
mono.e:
	mono Program.exe
 
clean:
	rm *.exe
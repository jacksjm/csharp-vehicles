output: mcs.e mono.e clean
 
mcs.e:
	mcs Program.cs Views/lib/Libs.cs Views/CustomerCreate.cs Controllers/* Repository/* Models/* -r:System.Windows.Forms.dll,System.Drawing.dll,Microsoft.EntityFrameworkCore.dll
 
 
mono.e:
	mono Program.exe
 
clean:
	rm *.exe
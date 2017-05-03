# fsirun

A small (6kb) executable to run fsi.exe without assuming it's on PATH. Often, it's not.

Installation:

Grab the exe from https://github.com/vivainio/fsirun/releases/download/v0.1/fsirun.exe and drop it somewhere (e.g. next to your .fsx files).


Usage: 

```
fsirun.exe foo.fsx [any other args you can pass to fsi.exe]
```


Written in C#, because everything else creates too large executables.

License: MIT

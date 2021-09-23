# Make sure you have the Vsts Credential Provider installed
# See: https://github.com/microsoft/artifacts-credprovider#azure-artifacts-credential-provider

param(
    [string] $file,
    [string] $packageDirectory = "./bin/Debug"
)

function selectPackage() {
	$choices = @()
	$packageFiles = Get-ChildItem $packageDirectory -Filter "*.nupkg"
	
	foreach($file in $packageFiles) {
        $choices += $file.Name
	}	

	if($choices.length -eq 1) {
		return $choices[0]
	}

	Write-Host "Please input the number of the package you want to publish. Hit [enter] without input for the latest"
	for($i = 0; $i -lt $choices.Count; $i++) {
        $item = $choices[$i]
		Write-Host "	$i -> $item"
	}
	
	$choice = Read-Host "Input choice: (hit [enter] without input for latest)"
	
    if([string]::IsNullOrEmpty($choice)) {
	    return $choices[$choices.Count-1]
    }

	for($i=0; $i -lt $choices.Count; $i++) {
		if($choice -eq $i) {
			return $choices[$i]
		}
	}

	Write-Host "Invalid choice."
	return selectPackage
}

dotnet restore --interactive
dotnet build

if([string]::IsNullOrEmpty($file)) {
	$file = selectPackage
}
Write-Host "Publishing package $file"

dotnet nuget push "bin/debug/$file" --api-key az --source ridder-gs --interactive
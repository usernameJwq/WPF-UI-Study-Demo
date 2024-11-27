param (
	[Alias("v")]
	[string]$appVersion,

	[Alias("c")]
	[string]$channel = "stable"
)

# App 信息
$appName = "WPF-UI-Study"
$appDisplayName = "WPF-UI-Study"

# 当前脚本所在目录
$scrpitDir = $PSScriptRoot
$rootDir = Join-Path $scrpitDir ".."

function Get-VersionFromProjectFile {
	param (
		[string]$projectFilePath
	)
	
	# 读取文件内容
	$xmlContext = [xml](Get-Content $projectFilePath)
	
	# 查找版本号
	$version = $xmlContext.Project.PropertyGroup.VersionPrefix
	return $version
}

function Check-And-Install-Vpk {
	if(-not (Get-Command vpk -ErrorAction SilentlyContinue)) {
		Write-Host "vpk not found. Attempting to install using dotnet tool."
		
		if(-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
			& dotnet tool update -g vpk
            if ($LASTEXITCODE -ne 0) {
                Write-Error "Failed to install vpk using dotnet tool."
                exit 1
            }
        } else {
            Write-Error "vpk not found and dotnet is not installed. Please install vpk using 'dotnet tool update -g vpk'."
            exit 1
        }
	} else {
		# Write-Host "vpk is already installed."
	}
}

# 查找最新版的 MSBuild 编译项目
Write-Host "Building project in Release configuration..."

$vswherePath = Join-Path $scrpitDir "vswhere.exe"
$msbuildPath = & $vswherePath -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe

$projectFilePath = Join-Path $scrpitDir "..\$appName.csproj"
& $msbuildPath $projectFilePath /p:Configuration=Release
 
if(-not $appVersion) {
	try {
		$appVersion = Get-VersionFromProjectFile $projectFilePath
		$appVersion = $appVersion.Trim()
	} catch {
		Write-Error $_.Exception.Message
		exit 1
	}
}

# 打包
write-Host "Building Velopack Release v$appVersion"
$vpkPath = "Vpk"
$releaseDir = Join-Path $rootDir "Release"
$binReleaseDir = Join-Path $rootDir "bin\Release\net8.0-windows"

& $vpkPath pack --channel $channel -o $releaseDir -u $appName -v $appVersion -p $binReleaseDir -f net8.0-x64-desktop --packTitle $appDisplayName
 
Write-Host "Files copied successfully."
Write-Host "Version $appVersion has been successfully released."
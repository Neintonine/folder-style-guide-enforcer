﻿using System.Collections;

namespace FSGE.Framework.FileProviders;

public class DirectoryProvider : IProvider
{
    private readonly string _path;
    private IEnumerable<string> _directoryEnum;

    public DirectoryProvider(string path)
    {
        this._path = path;
        this._directoryEnum = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
    }

    public string GetAbsolutePath(string relativePath)
    {
        return Path.GetFullPath(relativePath, this._path);
    }

    public IEnumerator<string> GetEnumerator()
    {
        return new DirectoryProviderEnumerator(this._path, this._directoryEnum.GetEnumerator());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
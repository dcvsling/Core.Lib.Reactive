# Simple Reactive

[![MyGet](https://www.myget.org/BuildSource/Badge/core-lib?identifier=af0916bb-a2f1-4586-82ad-d0e6c4296d86)](https://www.myget.org/feed/core-lib/package/nuget/Core.Lib.Decorator)

�o�O Reactive Extensions ����¦�����ҫإߪ� Fluent Service Chain

�o�ӱM�צs�b���ηN�O�Ʊ���Ǧ��M�רӭ��s�{�� Reactive Extensions �үవ�쪺�Ʊ�


## How To Use


�ϥΤ覡�w�g�ɥi�઺�P Rx �Ϊk�ۦP, �åB�㦳 Fluent, Map, Notify���\��

���O�����p�U :

Observable => ServiceClient

Observer => Service

Subject => ServiceChannel

�󴫦W�r���ت��O���F�ư����T���� Observable ����O����

�ϥΤ覡�p�U

```csharp
    
    var actual = string.Empty;
    var input = Chain.From<string>();

    await input.Next(x => x.ToString())
        .Next(x => x.Count())
        .Run(x => actual = x.ToString());

    input.Execute(this);
    // actual will be this type to string's length string    

```

��h�ϥΤ覡�i�ѦҴ��ձM��

## Rx�٦�����?

Rx ���B�ΤF�D�`�h����N���}�o�޳N 

���O�������ϥ� Flient Interface �Ӧ걵��k

�z�L Currying ������²�ƫD�P�B���Ƥ���D

�Q�� Fluent Interface �H��²�檺�覡���� Constructor Injection Decorator

�� Observable �M Observer ���椬���Y�ഫ���� ���� Proxy �������ӹ�ھާ@����

�N�\��Ӥ��ܪ�G�i�U�ۿW�� �ŦX solid, kiss ������h 

�ӥB �]�㦳 exception handling, finally, disposable ���ڭ̱`�`��|���F��

�u�n�B�αo��, �@�˥i�H�g�X���iŪ�ʪ��{���X (ex: �� lambda ���� method)

�̭����Ӧh�ȱo�@�ݪ��F��F

�o�ӱM�׶ȱN�D�n���X�ӥD�F�^���X�Ө�²�� ~~�N�O���ꪩ���N��~~

�ӧƱ�i�H�Ǧ����ϥΪ̤F�� �o�˪��F���٥i�H�p��ϥλP�X�i

## ı�o����?

�p�G�zı�o���Ҧ�ì �Ʀ�ı�o�ܦn�� ���ڷ|��ĳ�A�i�H�i�@�B�`�O�u���� Rx

�p�G�Aı�o�o������ ���O�z�ҷ�M�� �]���o�O���ꪩ �ҥH�z�����Өϥέ쥻�� Rx

�p�G�A�b�ϥΤW�����D �w��ϥ�Issue�ӵo��

�o�� project ���D�n�ت��ëD�Ʊ�j�a���ϥ� Rx

�ӬO�Ʊ�ɶq�קK�]���@�Ǧ]�����~���ЦӱN�o�˪��n�F��ư��b�`�ΩM�ǲߪ��Ҽ{���~

## NuGet Feed

���|��í�w���t�G�A�ҥH�ȮɨS���W���W��NuGet.org�A�p�G�Q�����Ѧ�Package�i�[�J�U�C NuGet Feed Url

https://www.myget.org/F/core-lib/api/v3/index.json

## License

MIT

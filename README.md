VesselTest
==========

Test Of Vessel

## 외부 버전 관리 시스템을 이용할 수 있도록 설정 변경하기

유니티 프로젝트를 외부 버전 관리 시스템에서 관리하려면 다음 두 가지 설정을 변경하면 된다.

메뉴: Edit > Project Settings > Editor > (Inspector 창)

![](/unity_guide.png)

1. 버전 관리 모드 변경: Version Control > Mode > Meta Files
2. 애셋 직렬화 모드 변경: Asset Serialization > Mode > Force Text

공식 문서인 [Using External Version Control Systems with Unity](http://docs.unity3d.com/Documentation/Manual/ExternalVersionControlSystemSupport.html)에는 Version Control Mode를 Asset Server에서  Meta Files로 바꾸라는 설명 뿐인데, 애셋 직렬화 모드를 변경하지 않으면 씬(Scene) 파일이 바이너리 포맷으로 유지된다.

씬 파일은 기본적으로 바이너리 포맷이고, 직렬화 모드를 변경해야 텍스트 파일로 변경된다. 씬 파일을 바이너리로 놔둔채로 Git이나 SVN에서 버전 관리를 하게 되면 공동 작업이 많이 불편해진다. 텍스트 형식도 알아보기 쉽지는 않지만 자동 merge와 자신이 변경한 내용인지 아닌지 정도는 구분할 수 있다는 차이가 있다.

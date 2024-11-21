### 11-11 작업
- SpawnManager 작업
    - 지난주에 구현한 GameObjectPool을 활용하여 오브젝트의 스폰요청을 받으면 자동으로 풀에서 꺼내거나 생성하여 오브젝트를 전달해주는 매니저 구현
- StageManager 작업
    - 스테이지의 몬스터 총량과 몬스터 스폰간격을 조절하여 몬스터를 스폰 하는 기능을 구현.

### 11-12 작업
- [-] enemy가 마지막 waypoint에 도착하면 enemy가 사라지면서 stageManager의 FailCount가 증가하도록 구현.  
- [-] currentenemeycount가 0일때 fail포인트를 비교하여 스테이지 클리어/실패 구현. failthreshold를 두어 일정 수 이하로 실패하면 성공할 수 있도록 구현 

### 11-13 
- 타워 설치 구현
    - MapTile에 OnMouseUP 이벤트 함수에 타워 설치 함수 구현
    
### 11-14
- 발사체 구현
    - IProjectileTrajectory 로 날아가는 궤적을 계산해서 이동하는 클래스 구현
    - IAttackType로 어택하게 하는 클래스 구현

### 11-18
- 타워 발사체 발사 구현
    - testbullet을 발사하도록 구현
    - 발사 테스트

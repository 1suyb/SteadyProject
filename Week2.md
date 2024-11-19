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

### 11-19
- Enemy에서 스탯 분리
- 얘 왜 또 하늘로 날지
- 적 피격 구현

- Todo  
    
    - 타워 공격 구현
        - 인식범위안에 들어오면 <발사체>을 발사
        - attackinterbaltime간격으로 공격 시전
    - 발사체 구현
        - https://suyb.tistory.com/84 전략 패턴을 활용해서 발사체의 움직임 구현
            - IProjectileTrajectory
        - 커맨드 패턴을 활용해서 발사체의 데미지 주는 방식을 구현
            - IAttackType
        - 팩토리 패턴을 활용해서 정보에 따라 발사체를 재조립 해줄 수 있음.

        - 투사체
            - 단일 타겟
                - like 젠야타
            - 범위 타겟
                - like 솔저 우클릭
                - like 장판 (솔저 힐장판 타격버전)
        - hitscan
            - like 솔저


    - UI 구현

    - 다양한 적 데이터를 받을 수 있게 구현
    - 다양한 타워 데이터 구현
        - 타워 설치 구현 수정 - id 에 따라서 서로 다른 타워가 설치되도록
    - 다양한 스테이지 구현
        - 타워 설치 구현 수정 - 스테이지 설정에 따라서 타워 개수가 제한되도록
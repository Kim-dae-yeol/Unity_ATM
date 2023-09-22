# Unity_ATM
ATM UI PROJECT - B07 김대열


## Unity Version
- ⚙️2022.3.5f1

## Overview
- 필수구현만 모두 구현했습니다.
- UI 조작을 절차적으로 하기보다 event를 통해서 연결을 해주는 방식으로 구현 
- 장점 : 내용이 변경되기 까지 한 단계 계층이 있어서 변화에 좀 더 유연하게 할 수 있다.
- 단점 : 보일러 플레이트 코드가 좀 더 많다.

## Preview 
<p>

  <img width="49%" alt="스크린샷 2023-09-20 오후 10 46 16" src="https://github.com/Kim-dae-yeol/Unity_ATM/assets/115692722/f50e342e-114b-462c-ad8b-cf90c1082b06">
<img width="49%" alt="스크린샷 2023-09-20 오후 10 46 43" src="https://github.com/Kim-dae-yeol/Unity_ATM/assets/115692722/75dbb576-b8a9-4a05-8da9-b54a9e550c62">
</p>
<p>
<img width="49%" alt="스크린샷 2023-09-20 오후 10 46 28" src="https://github.com/Kim-dae-yeol/Unity_ATM/assets/115692722/55b94bd5-1e4b-4d5c-92bf-79ec73ccaa6e">
<img width="49%" alt="스크린샷 2023-09-20 오후 10 46 22" src="https://github.com/Kim-dae-yeol/Unity_ATM/assets/115692722/5ccaba81-eebd-4f2c-b5bf-e367166553e5">  
</p>
<img width="49%" alt="스크린샷 2023-09-20 오후 10 47 10" src="https://github.com/Kim-dae-yeol/Unity_ATM/assets/115692722/88ea4bb4-b78b-4e84-a336-dabe0034f7af">


## 클래스 소개 
- ATM : 게임 매니저와 같은 역할을 하면서 UI 상태와 현재 돈에 관련된 상태를 저장하며 UI event 를 통제하는 역할을 한다. 전체 비즈니스 로직의 상태를 갖고 있기 때문에 Entity로 분류했다.
- UIState : 출금, 입금, 홈으로 나눠지며 상태 전환을 유연하게 동작하도록 클래스로 분할했다.
- 남은 UI 객체들은 각 UI 객체들의 스크립트이다.

## 후기

이번 주차 강의가 너무 만들고 싶은부분이 많게 잘 나와서 강의에 집중하려고 ATM을 했습니다.<br>
시간 내서 봐주셔서 감사합니다 🙇🏻‍♂️



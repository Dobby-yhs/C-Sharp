## C#의 공부 내용에 대한 정리를 위한 Repository입니다.

### Day 1
- 컴파일러와 인터프리터
- using static
- static void Main(string[] args) { }
- CLR
- C#의 컴파일

> My Blog Link
>   > *https://sunlight-dby.tistory.com/4*

### Day 2
- 변수
- 힙 메모리 영역
- 데이터 형식 : 정수형
- 오버플로우와 언더플로우
- 데이터 형식 : 실수형
- 데이터 형식 : 논리형
- 데이터 형식 : object 형식
	- 박싱과 언박싱

> My Blog Link
>   > *https://sunlight-dby.tistory.com/6*

### Day 3
- 형 변환(타입 캐스팅)
- 형 변환
	- 크기가 서로 다른 부동 소수점 형식 사이의 변환
	- 문자열과 숫자
- Nullable
- var
- 전역변수
- 문자열
	- 탐색 메서드
	- 변형 메서드
	- 분할 메서드
- 문자열의 서식
	- Format() 메서드
	- 문자열 보간

> My Blog Link
>   > *https://sunlight-dby.tistory.com/7*

### Day 4
- 삼항 연산자
- null 조건부 연산자
- 비트 연산자
- null 병합 연산자
- 연산자의 우선 순위

> My Blog Link
>   > *https://sunlight-dby.tistory.com/11*

### Day 5
- Switch
	- Switch문(Statement)
	- Switch식(Expression)
- 반복문
- 점프문

> My Blog Link
>   > *https://sunlight-dby.tistory.com/15*

### Day 6
- 메소드
- 매개변수
	- 참조에 의한 매개변수 전달
	- C#의 포인터
- 참조 반환값
- 출력 전용 매개변수 out
- 메소드 오버로딩
- 가변 개수의 인수
- 명명된 인수
- 선택적 인수
- 메소드 오버로딩 vs 선택적 매개변수
- 로컬 함수

> My Blog Link
>   > *https://sunlight-dby.tistory.com/17*

### Day 7
- 객체지향 프로그래밍 (OOP)
	- 객체
	- 클래스
	- 상속
	- 다형성
	- 캡슐화
- 클래스
	- 필드
	- 멤버
	- 클래스의 객체 생성
- 객체 : 생성자와 종료자
- 정적 필드와 정적 메소드
- 얕은 복사와 깊은 복사
- this 키워드
- this() 생성자

> My Blog Link
>   > *https://sunlight-dby.tistory.com/19*

### Day 8
- 접근 한정자 : 은닉성
- 상속
- base 키워드
- sealed 한정자
- is 연산자
- as 연산자
- 오버라이딩과 다형성
- 메소드 숨기기
	- 정적 바인딩
	- 동적 바인딩
- 오버라이딩 봉인 : sealed 키워드
- 읽기 전용 필드
- 중첩 클래스
- 분할 클래스
- 확장 메소드

> My Blog Link
>   > *https://sunlight-dby.tistory.com/21*

### Day 9
- 구조체
	- 클래스 vs 구조체
- 변경 불가능 객체
	- 변경 불가능 구조체
- 읽기 전용 메소드
- 튜플
	- 튜플 분해

> My Blog Link
>   > *https://sunlight-dby.tistory.com/23*

### Day 10
- 인터페이스
- 인터페이스 다중 상속
- 인터페이스 기본 구현 메소드
- 추상 클래스
	- 추상 메소드

> My Blog Link
>   > *https://sunlight-dby.tistory.com/25*

### Day 11
- 프로퍼티
- 자동 구현 프로퍼티
	- 자동 구현 프로퍼티 뒤에서 일어나는 일
	- ILDASM
- 프로퍼티와 생성자
- 초기화 전용 자동 구현 프로퍼티
- 레코드 형식으로 만드는 불변 객체
- with을 이용한 레코드 복사
- 레코드 객체 비교하기
- 무명 형식
- 인터페이스의 프로퍼티
- 추상 클래스의 추상 프로퍼티

> My Blog Link
>   > *https://sunlight-dby.tistory.com/26*

### Day 12
- 배열
	- System.Index & ^연산자
	- 배열의 초기화
	- System.Array
		- Array 클래스의 주요 메서드와 프로퍼티
		- 이진 탐색
		- 선형 탐색
		- Array.TrueForAll<T>() 메서드
		- 람다식
		- Action 대리자
	- 배열의 분할
- 2차원 배열
- 다차원 배열
- 가변 배열
	- 선언 방식
	- 작동 방식
	- 선언과 초기화

> My Blog Link
>   > *https://sunlight-dby.tistory.com/30*

### Day 13
- 컬렉션
	- ArrayList
	- Queue
	- Stack
	- Hashtable
- 컬렉션을 초기화하는 방법
	- ArrayList, Queue, Stack의 초기화
	- Hashtable의 초기화
- 인덱서
- foreach가 가능한 객체 만들기
	- foreach 문 작동 방식
	- yield 문
	- IEnumerator

> My Blog Link
>   > *https://sunlight-dby.tistory.com/32*

### Day 14
- 일반화 프로그래밍
	- 일반화 메서드
	- 일반화 클래스
	- where 절 : 특정 조건을 갖춘 형식에만 대응하는 형식 매개변수
- 일반화 컬렉션
	- List<T>
	- Queue<T>
	- Stack<T>
	- Dictionary<TKey, TValue>
- foreach가 가능한 일반화 클래스

> My Blog Link
>   > *https://sunlight-dby.tistory.com/34*

### Day 15
- 예외 처리
- try ~ catch
- System.Exception 클래스
- 예외 던지기 : throw 문
- try ~ catch & finally
- 사용자 정의 예외 클래스
- 예외 필터
- 예외 처리의 용이성

> My Blog Link
>   > *https://sunlight-dby.tistory.com/36*

### Day 16
- 대리자
	- 대리자의 사용
	- 일반화 대리자
- 대리자 체인 : 멀티캐스팅
- 대리자의 익명 메서드 사용
- 이벤트
	- 대리자와 이벤트

> My Blog Link
>   > *https://sunlight-dby.tistory.com/38*

### Day 17
- 람다식
	- 문 형식의 람다식
	- Fuc와 Action을 활용한 무명 함수
- 식 트리
	- Expression 클래스의 파생 클래스
		- 팩토리 메서드
	- 식 트리를 사용하는 이유
	- 식 트리를 동적으로 만들어야 할 이유
	- 식 본문 멤버
- LINQ
	- from
	- where
	- orderby
	- select
	- group by
	- group by into
	- join
		- Inner Join
		- Outer Join

> My Blog Link
>   > *https://sunlight-dby.tistory.com/40*
>   > *https://sunlight-dby.tistory.com/41*

### Day 18
- 리플렉션
	- Object.GetType() 메서드와 Type 클래스
	- 리플렉션을 이용해서 객체 생성하고 이용하기
	- 리플렉션을 이용해서 형식 내보내기
- 어트리뷰트
	- 호출자 정보 어트리뷰트
	- 사용자 정의 어트리뷰트

> My Blog Link
>   > *https://sunlight-dby.tistory.com/43*
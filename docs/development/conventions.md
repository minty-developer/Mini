# Project Conventions

이 문서는 프로젝트의 코드 작성 및 개발 규칙을 정의합니다.

## 1. Naming

프로젝트 내 이름은 다음 규칙을 따릅니다.

| 대상           | 규칙           | 예시               |
| -------------- | ------------- | ----------------- |
| Class          | PascalCase    | `UserManager`     |
| Method         | PascalCase    | `GetUser()`       |
| Property       | PascalCase    | `UserName`        |
| Local Variable | camelCase     | `userName`        |
| Parameter      | camelCase     | `userId`          |
| Private Field  | `_camelCase`  | `_userManager`    |
| Interface      | `IPascalCase` | `IUserRepository` |
| Enum           | PascalCase    | `UserStatus`      |
| Enum Member    | UPPERCASE     | `ACTIVE`          |

## 2. File & Folder Structure

* 파일명은 camelCase를 사용합니다.
* 주요 클래스의 파일명은 클래스명과 일치해야 합니다.
* 하나의 파일에는 하나의 주요 클래스를 작성합니다.
* 폴더 이름은 camelCase를 사용합니다.
* Namespace는 프로젝트의 폴더 구조와 일관성을 유지합니다.

예:

```text
services/
└─ userService.cs
```

```csharp
namespace project.Services;
```

## 3. Code Formatting

* 들여쓰기는 Tab을 사용합니다.
* 중괄호는 Allman Style을 사용합니다.
* 불필요한 빈 줄과 공백은 사용하지 않습니다.

예:

```csharp
if (isValid)
{
    DoSomething();
}
```

## 4. Comments

주석은 코드의 동작보다는 **작성 이유와 의도**를 설명하는 데 사용합니다.

좋은 예:

```csharp
// Keep the connection alive during matchmaking.
connection.KeepAlive();
```

불필요한 예:

```csharp
// Increment count.
count++;
```

## 5. Error Handling

* 예외를 무시하지 않습니다.
* 예상하지 못한 예외는 적절한 방법으로 기록합니다.
* 클라이언트에게 내부 구현 정보나 예외의 상세 내용을 노출하지 않습니다.
* 프로젝트의 목적에 맞는 예외 처리 방식을 사용합니다.

## 6. Logging

* 프로젝트의 Logging 시스템을 사용합니다.
* 단순한 디버깅 목적이 아니라면 `Console.WriteLine()`을 사용하지 않습니다.
* 로그에 민감한 정보를 기록하지 않습니다.

다음 정보는 로그에 기록하지 않습니다.

* Password
* API Key
* Access Token
* Refresh Token
* 기타 인증 정보

## 7. Asynchronous Code

* I/O 작업에는 `async` / `await` 사용을 우선합니다.
* 비동기 메서드는 `Async` 접미사를 사용합니다.
* 비동기 작업에서 `.Result` 또는 `.Wait()` 사용을 피합니다.

예:

```csharp
public async Task<User> GetUserAsync(int userId)
{
    // ...
}
```

## 8. Git

### Branch Naming

브랜치 이름은 다음 형식을 사용합니다.

```text
feature/<name>
fix/<name>
refactor/<name>
docs/<name>
```

## 9. Security

* 비밀번호와 인증 정보를 소스 코드에 직접 작성하지 않습니다.
* API Key와 Secret은 Repository에 커밋하지 않습니다.
* 민감한 정보는 환경 변수 또는 별도의 Secret 관리 방법을 사용합니다.
* 사용자 입력은 항상 신뢰할 수 없는 데이터로 취급합니다.

## 10. General Rules

* 기존 프로젝트의 규칙과 일관성을 유지합니다.
* 새로운 규칙이 필요할 경우 문서를 먼저 업데이트합니다.
* 명확하지 않은 코드는 가능한 한 단순하게 작성합니다.
* 사용하지 않는 코드와 불필요한 주석은 제거합니다.
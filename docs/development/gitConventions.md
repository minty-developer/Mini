## Git

### Branch

- `main` — stable
- `develop` — development
- `feature/*` — new features
- `fix/*` — bug fixes

### Commit

Use:

`<type>: <description>`

| Type       | 의미                | 예시                                   |
| ---------- | ----------------- | ------------------------------------ |
| `init`     | 프로젝트 초기화 (첫 커밋에만 사용) | `init: initialize repository` |
| `feat`     | 새로운 기능            | `feat: add guild system`             |
| `fix`      | 버그 수정             | `fix: fix client disconnect error`   |
| `refactor` | 기능 변화 없이 코드 구조 개선 | `refactor: simplify socket handling` |
| `docs`     | 문서 수정             | `docs: update README`                |
| `style`    | 코드 스타일/포맷 변경      | `style: format Lobby.cpp`            |
| `test`     | 테스트 추가/수정         | `test: add lobby server tests`       |
| `chore`    | 기타 작업             | `chore: update dependencies`         |
| `perf`     | 성능 개선             | `perf: optimize packet processing`   |
| `build`    | 빌드 관련             | `build: update CMake configuration`  |
| `ci`       | CI/CD 관련          | `ci: add GitHub Actions workflow`    |


### Examples
git add .
git commit -m "<type>: <commit_Name>"

git tag -a <Version> -m "Release <Version>"

git push
git push origin <Version>
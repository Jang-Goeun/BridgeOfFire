# 🔥 Bridge Of Fire
> **HCI 사이언스 VR/AR 전공 프로젝트 (A+ 수강작)**  
> 설계부터 구현까지 프로세스 기반으로 완성한 2D 액션 플랫폼 게임

[![Portfolio](https://img.shields.io/badge/Check_My-Portfolio-blue?style=for-the-badge&logo=googlechrome&logoColor=white)](https://jang-goeun.github.io/Portfolio/bridge_of_fire/bridge_of_fire.html)
[![GitHub Repository](https://img.shields.io/badge/GitHub-Repository-181717?logo=github)](https://github.com/Jang-Goeun/BridgeOfFire)

<br>

## 📌 Project Overview
한 학기 동안 학습한 게임 설계 프로세스를 실제 개발 현장에 적용해 보는 것을 핵심 목표로 삼은 프로젝트입니다. 단순한 기능 구현을 넘어, 교수님의 피드백을 수렴하며 공간적 완성도와 기능적 디테일을 높이는 데 집중했습니다.

- **개발 기간**: 2025.06.20 ~ 2025.06.22 (3일)
- **개발 환경**: Unity 2D, C#, Visual Studio 2022
- **주요 성과**: 전공 과제 만점 (A+) 획득
- **핵심 역할**: 1인 개발 (기획, 레벨 디자인, 스크립트 구현)

<br>

## 🛠 Tech Stack
- **Engine**: Unity 2D
- **Language**: C#
- **Patterns**: Singleton Pattern (BGM 관리)
- **Physics**: Rigidbody2D, Collision/Trigger System

<br>

## 🕹 Key Development Logics

### 1. 가변 난이도 시스템 (Dynamic Difficulty)
시간 경과에 따라 불덩이 생성 주기(`span`)를 유동적으로 조절하여 후반부 긴장감을 조성했습니다. 외부 파라미터 주입형 구조로 설계하여 유지보수성을 높였습니다.

```csharp
public void SetParameter(float span) {
    this.span = span;
}

void Update() {
    this.delta += Time.deltaTime;
    if(this.delta > this.span) {
        this.delta = 0;
        GameObject fireBall = Instantiate(FireBallPrefab);
        float y = Random.Range(-4, 4);
        fireBall.transform.position = new Vector3(64, y, 0);
    }
}

```

### 2. 코루틴 기반 지연 낙하 브릿지 (Delayed Fall)

플레이어가 발판에 닿았을 때 `IEnumerator` 비동기 로직을 통해 3초의 유예 시간을 부여합니다. 단순 추락이 아닌 전략적인 이동 타이밍을 유도했습니다.

```csharp
IEnumerator EnableGravityAfterDelay(float delay) {
    yield return new WaitForSeconds(delay);
    rigid2D.bodyType = RigidbodyType2D.Dynamic;
}

```

### 3. BGM 싱글톤 패턴 (BGM Singleton)

`DontDestroyOnLoad`와 싱글톤 패턴을 결합하여 씬이 전환되어도 배경음이 끊기지 않는 연속성을 확보했습니다.

<br>

## 🚀 Trouble Shooting & Feedback

* **파티클 방향 오류**: 불덩이 파티클이 반대로 출력되는 문제를 실시간 테스트와 옵션 수치 조정을 통해 해결했습니다.
* **카메라 트래킹 예외**: 시작 지점 반대 방향으로 추락 시 발생하는 카메라 이탈 문제를 물리적 충돌체(Collider) 벽을 배치하여 시스템적으로 제약했습니다.
* **교수님 피드백 반영**: `SceneManager`를 통한 씬 전환 시스템 구축, 징검다리 높낮이 조절을 통한 공간 몰입감 강화 등을 수행했습니다.

<br>

## 📂 Documentation

* [초기 프로젝트 기획안 (PDF)](https://jang-goeun.github.io/Portfolio/bridge_of_fire/file/plan.pdf)
* [최종 결과 보고서 (PDF)](https://jang-goeun.github.io/Portfolio/bridge_of_fire/file/report.pdf)
* [게임 플레이 시연 영상 (MP4) 및 사진은 포트폴리오에서 확인 가능합니다.](https://jang-goeun.github.io/Portfolio/bridge_of_fire/bridge_of_fire.html)

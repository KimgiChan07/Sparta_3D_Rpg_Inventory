# Sparta 3D RPG Inventory System

Unity 기반 3D RPG 게임용 인벤토리 시스템 실습 프로젝트입니다. 아이템 수집, JSON 기반 데이터 저장, UI 연동 등 실전 기능을 구현하였습니다.

## 📁 프로젝트 구조

Sparta_3D_Rpg_Inventory-main/

├── Assets/

│ ├── Font/ # 폰트 리소스

│ ├── Image/ # 아이콘 및 UI 이미지

│ ├── ItemsData/ # 아이템 JSON 및 ScriptableObject

│ ├── Prefabs/ # 캐릭터 및 UI 프리팹

│ ├── Scenes/ # 메인 씬

│ ├── Scripts/

│ │ ├── GameManager.cs

│ │ ├── InventoryManager.cs

│ │ ├── Item/ # 아이템 로직 관련

│ │ ├── JsonPratic/ # JSON 입출력 처리

│ │ └── UI/ # UI 처리 스크립트

│ └── TextMesh Pro/ # TMPro 설정

├── Packages/

├── ProjectSettings/

## 🛠 주요 기능

- **인벤토리 시스템**: 아이템 등록, 장착, 해제 구현
- **ScriptableObject 기반 아이템 관리**
- **JSON 저장/로드 기능**: 아이템 상태를 JSON으로 저장
- **UI 연동**: 슬롯 자동 생성, 장착 시 표시 변화 등
- **프리팹화 구조**: 아이템/슬롯/캐릭터 프리팹으로 분리

## 🚀 시작 방법

1. Unity 2021 이상에서 프로젝트 폴더 열기
2. `MainScene` 실행
3. 인벤토리 UI 열기 → 아이템 추가/장착 확인


> 또는 GitHub Release에 실행 파일 첨부 가능

## 🧱 개발 환경

- Unity 2021.3 이상 권장
- TextMesh Pro 사용

## 🙋‍♂️ 만든 사람
- 김기찬
  

# Vocabify

## Entity-Related Diagram

```mermaid
erDiagram
  USER {
    Id string PK
    Email string UK
    PasswordHash string
    EmailVerifiedAt date
  }

  SET {
    Id string PK
    Title string
    Description string
    Image string
    TextLang string
    DefinitionLang string
    Url string
    ItemsCount int
    UserId string FK
  }

  TERM {
    Id string PK
    Text string
    Definition string
    Image string
    TextTtsUrl string
    DefinitionTtsUrl string
    SetId string FK
  }

  USER ||--|{ SET : has
  SET ||--|{ TERM : contains
```

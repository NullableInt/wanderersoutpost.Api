# API reference

## Api test methods

### Test api is live with public endpoint

#### Request

```
HTTP GET /Api/Public
```

#### Response

```
Responsecode 200 OK
```

### Test api is live with private endpoint

#### Request

```
HTTP GET /Api/Private
Authorization: Bearer
```

#### Response if authorized

```
Responsecode 200 OK
```

#### Response if not authorized

```
Responsecode 401 UNAUTHORIZED
```

### Check what claims you currently have access to

#### Request

```
HTTP GET /Api/Claims
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
[
    {
        "type": "iss",
        "value": "https://rpgcharapi.eu.auth0.com/"
    },
    {
        "type": "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
        "value": "uniqueIdForUser"
    },
    {
        "type": "aud",
        "value": "https://rpgCharAuthUrlIdentifier.hi"
    },
    {
        "type": "aud",
        "value": "https://rpgcharapi.eu.auth0.com/userinfo"
    },
    {
        "type": "iat",
        "value": "1557211299"
    },
    {
        "type": "exp",
        "value": "1557218499"
    },
    {
        "type": "azp",
        "value": "6bD17UhET0jgkqvnuCZ7Zcv06tipiVx1"
    },
    {
        "type": "scope",
        "value": "openid profile email "
    }
]
```

### Get a mock of a character model

#### Request

```
HTTP GET /api/mock
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "id": "5cd13c18bd0cdbf3fcbec3c0",
    "ownerID": "Unique ID for owner from identity federation",
    "profile": {
        "characterName": "Testy testerson",
        "characterImage": "Url here",
        "background": "Is this a duplicate from Features and traits?",
        "playerName": "U+1F618",
        "race": "U+1F364",
        "alignment": "Truly evil",
        "diety": "",
        "typeClass": "God",
        "gender": "No",
        "age": "23",
        "level": 2,
        "exp": "Milestone"
    },
    "traits": [
        {
            "name": "Trait name",
            "race": "Racism",
            "description": "Trait"
        }
    ],
    "items": [
        {
            "name": "Woah",
            "desc": "Oh no",
            "qty": 1,
            "weight": 154,
            "cost": 14,
            "currencyDenomination": "SP"
        }
    ],
    "abilityScores": {
        "str": "4",
        "dex": "6",
        "con": "7",
        "int": "5",
        "wis": "3",
        "cha": "8"
    },
    "status": [
        {
            "identifier": "Dead,y",
            "type": "Forcy",
            "name": "Unknown",
            "value": 13
        }
    ],
    "hitDice": [
        {
            "hitDiceUsed": 1,
            "extraHitDice": 0
        }
    ],
    "health": {
        "maxHitpoints": 6,
        "tempHitpoints": 2,
        "damage": 1
    },
    "savingThrows": [
        {
            "name": "Dex",
            "proficiency": true
        },
        {
            "name": "Int",
            "proficiency": false
        }
    ],
    "skills": [
        {
            "bonusModifier": 1,
            "name": "Prospecting",
            "abilityScore": "Wis",
            "ProficiencyModifier": 2
        }
    ],
    "hitDiceType": [
        {
            "hitDiceType": "d8"
        }
    ],
    "deathSave": [
        {
            "deathSaveSuccess": false,
            "deathSaveFailure": true
        },
        {
            "deathSaveSuccess": true,
            "deathSaveFailure": false
        }
    ],
    "treasure": [
        {
            "platinum": "1",
            "gold": "0",
            "electrum": "4",
            "silver": "0",
            "copper": "0"
        }
    ],
    "characterAppearance": [
        {
            "height": "Height",
            "weight": "Weight",
            "hairColor": "Hair",
            "eyeColor": "Eye",
            "skinColor": "Skin"
        }
    ],
    "featuresTraits": [
        {
            "background": "Noble",
            "ideals": "Few",
            "flaws": "Very",
            "bonds": "Bondy bond"
        }
    ],
    "equipment": {
        "weapons": [
            {
                "name": "Weapon",
                "type": "Type",
                "dmg": "2d6",
                "handedness": "Left",
                "ProficiencyModifier": 0.5,
                "price": 1,
                "currencyDenomination": "d",
                "hit": -1,
                "toHitModifier": -1,
                "weight": 1,
                "range": "5ft",
                "damageType": "Force",
                "property": "Prop",
                "description": "Lightsaber",
                "quantity": 1
            }
        ],
        "armor": [
            {
                "name": "Name",
                "type": "Type",
                "price": 1,
                "magicalModifier": 1,
                "currencyDenomination": "What",
                "weight": 12,
                "class": 11,
                "stealth": "1",
                "description": "Desc",
                "equipped": "eq"
            }
        ]
    },
    "magicItems": [
        {
            "name": "Boy",
            "type": "Unknown",
            "rarity": "Legendary",
            "requiresAttunement": true,
            "attuned": true,
            "maxCharges": 1,
            "charges": 0,
            "weight": 14,
            "description": "No ide"
        }
    ],
    "notes": [
        {
            "text": "Test text",
            "isSavedChatNotes": true
        }
    ],
    "spells": {
        "spellcastingAbility": "All so fuck you",
        "spellSaveDc": 19,
        "spellAttackBonus": 42,
        "spellsKnown": 1,
        "cantripsKnown": 1,
        "invocationsKnown": 1,
        "maxPrepared": 13,
        "spellSlots": [
            {
                "level": 1,
                "usedSpellSlots": 0,
                "resetsOn": "Seconds",
                "availableSpellSlots": 0
            }
        ],
        "spellList": [
            {
                "name": "Lie",
                "prepared": true,
                "alwaysPrepared": true,
                "type": "All",
                "saveAttr": "Int",
                "dmg": "6d8",
                "dmgType": "Psycic",
                "school": "Godlike",
                "level": 99,
                "description": "Tells a lie",
                "castingTime": "1 turn",
                "range": "32ft",
                "components": "Verbal",
                "duration": "Lifetime",
                "materialComponents": "None",
                "isRitual": false
            }
        ],
        "cantrips": [
            {
                "name": "Lie",
                "type": "All",
                "saveAttr": "Int",
                "dmg": "6d8",
                "dmgType": "Psycic",
                "school": "Godlike",
                "description": "Tells a lie",
                "castingTime": "1 turn",
                "range": "32ft",
                "components": "Verbal",
                "duration": "Lifetime",
                "materialComponents": "None",
                "isRitual": false
            }
        ]
    },
    "feats": [
        {
            "name": "Halfling nibleness",
            "description": "Allows you to sneak past friends"
        }
    ]
}
```

## Generic character controller

The Generic controller under the root path of `\` is a result of testing reflection and having fun with generics with a result of a working API.

### Get all characters for logged in user

This will return a list of all ID's connected to user logged in.

#### Request

```
HTTP GET /
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
["Array","of","the","ids"]
```

### Create a character

Current supported `gameSystem`s are `RpgChar` and `CallOfCthulu`.

#### Request

```
HTTP POST /create/{gameSystem}
{
    Optional Json body
}
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
"{idOfNewCharacter}"
```

### Get Info of one character

This will return all the properties of the requested id (if found) as a list of URLs.

#### Request

```
HTTP GET /{id}
```

#### Response

Example response for a campaign

```
Responsecode 200 OK
Content-Type: application/json
{
    "characters": "/5cf11bbb8ca3773b6ce45eda/characters",
    "session": "/5cf11bbb8ca3773b6ce45eda/session",
    "campaignImage": "/5cf11bbb8ca3773b6ce45eda/campaignImage",
    "campaignType": "/5cf11bbb8ca3773b6ce45eda/campaignType"
}
```

### Request info about a property

Using the result from the previous request you get a series of links you can do `GET` or `PUT` requests to,
if you send a `GET` request to a `property url` you will get the structure of that property.

#### Request example for a CallOfCthulu profile information

```
HTTP GET /{id}/profile
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "characterName": null,
    "playerName": null,
    "occupation": null,
    "age": null,
    "sex": null,
    "residence": null,
    "birthplace": null
}
```

### Update info about a property

Continuing to use the result from our previous `GET` we can see what properties are available.
We will use this to update the `characterName` and `occupation` as an example.

#### Request

```
HTTP PATCH /{id}/profile
{
	"characterName": "H.P. LoveCraft",
	"occupation": "Weird writer"
}
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "characterName": "H.P. LoveCraft",
    "playerName": null,
    "occupation": "Weird writer"
    "age": null,
    "sex": null,
    "residence": null,
    "birthplace": null
}
```

### Delete a character

This deletes a character

#### Request

```
HTTP DELETE /{id}
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
{Id of deleted character}
```

## Campaigns

Campaigns are quite simple. A list of `characterId`s and sessions.
Create one, add some characters and start playing sessions!

### Create a campaign

#### Request

Create a campaign for a game system, currently supported are `RpgCharModel` and `CallOfCthulu`

```
HTTP POST /campgain/create/{gameSystem}
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
{Id of new campagin}
```

### Add a character to a campagin

To add a character simply send add the ID of the character to a campaign, make sure they are created using the same `gameSystem`!

#### Request

```
HTTP POST /campgain/{campaignId}/add/{characterId}
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
{Id of campagin}
```

# The following is kinda deprecated

## RpgChar api methods

This api and its methods are for getting and manipulating either an entire RpgChar or only parts of its model.
All of the methods available in `/RpgChar` are also available under the alias `/characters`
It's made with the idea that you can access parts of the model using the same accessor as in JavaScript. Access the api by using `/RpgChar/{idOfChar}/{partToGetOrModify}`

### Get all characters for logged in user

#### Request

```
HTTP GET /RpgChar
```

#### Response if no characters are created

```
Responsecode 204 No Content
```

#### Response if at least one character is found

The model structure is identical to the the one returned from `api/Mock`.
The return type of this is a list of characters.

```
Responsecode 200 OK
Content-Type: application/json
[
  {
    "abilityScores": {...},
    "characterAppearance": {...},
    "deathSave": {...},
    "equipment": {...},
    "feats": {...},
    "featuresTraits": {...},
    "health": {...},
    "hitDice": {...},
    "hitDiceType": {...},
    "id": "5cd122da686a1f1b20a79b16",
    "items": {...},
    "magicItems": {...},
    "notes": {...},
    "ownerID": "uniqueIdForUser",
    "profile": {...},
    "savingThrows": {...},
    "skills": {...},
    "spells": {...},
    "status": {...},
    "traits": {...},
    "treasure": {...}
  },
  {
    "abilityScores": {...},
    "characterAppearance": {...},
    "deathSave": {...},
    "equipment": {...},
    "feats": {...},
    "featuresTraits": {...},
    "health": {...},
    "hitDice": {...},
    "hitDiceType": {...},
    "id": "5cd1249b5dea4bee34710778",
    "items": {...},
    "magicItems": {...},
    "notes": {...},
    "ownerID": "uniqueIdForUser",
    "profile": {...},
    "savingThrows": {...},
    "skills": {...},
    "spells": {...},
    "status": {...},
    "traits": {...},
    "treasure": {...}
  },
  {
    "abilityScores": {...},
    "characterAppearance": {...},
    "deathSave": {...},
    "equipment": {...},
    "feats": {...},
    "featuresTraits": {...},
    "health": {...},
    "hitDice": {...},
    "hitDiceType": {...},
    "id": "5cd1295c510de6556472430e",
    "items": {...},
    "magicItems": {...},
    "notes": {...},
    "ownerID": "uniqueIdForUser",
    "profile": {...},
    "savingThrows": {...},
    "skills": {...},
    "spells": {...},
    "status": {...},
    "traits": {...},
    "treasure": {...}
  }
]
```

### Get one character

#### Request

```
HTTP GET /RpgChar/{id}
```

#### Response

```
Responsecode 200 OK
Content-Type: application/json
{
"abilityScores": {...},
"characterAppearance": {...},
"deathSave": {...},
"equipment": {...},
"feats": {...},
"featuresTraits": {...},
"health": {...},
"hitDice": {...},
"hitDiceType": {...},
"id": "idPassedInTheRequest",
"items": {...},
"magicItems": {...},
"notes": {...},
"ownerID": "uniqueId",
"profile": {...},
"savingThrows": {...},
"skills": {...},
"spells": {...},
"status": {...},
"traits": {...},
"treasure": {...}
}
```

### Create a new character

This method can take either nothing, an id for the new character, or an id for the new character and a model.
It will always return the ID for the character if it can be created.

### Request urls

```
HTTP POST /RpgChar/
HTTP POST /RpgChar/{id}
HTTP POST /RpgChar/{id} with JsonBody
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
"idOfNewCharacter"
```

### Create a new character with default not-null fields

This method is a lot like a previous create character, but it does not allow you to send in a body, but will instead pre-fill all fields with non-null variables, saving a lot of null-checks if such is wanted.

### Request url

Request has an optional id.

```
HTTP GET /RpgChar/newChar/
HTTP GET /RpgChar/newChar/{id}
HTTP POST /RpgChar/newChar/
HTTP POST /RpgChar/newChar/{id}
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
"idOfNewCharacter"
```

### Delete a character

### Request url

```
HTTP DELETE /RpgChar/{id}
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
"idOfDeletedCharacter"
```

### Get part of model

By using the part of the model you can get just a scoped response, this makes it more light weight for the front end if you want to load several characters, or if you want to test with just certain parts of the code.

### Request url for getting profile

```
HTTP GET /RpgChar/{id}/Profile
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "characterName": "Testy testerson",
    "characterImage": "Url here",
    "background": "Is this a duplicate from Features and traits?",
    "playerName": "U+1F618",
    "race": "U+1F364",
    "alignment": "Truly evil",
    "diety": "",
    "typeClass": "God",
    "gender": "No",
    "age": "23",
    "level": 2,
    "exp": "Milestone"
}
```

### Request url for getting traits

```
HTTP GET /RpgChar/{id}/Traits
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "traits": [
        {
            "name": "Trait name",
            "race": "Racism",
            "description": "Trait"
        }
    ]
}
```

### Request url for getting items

```
HTTP GET /RpgChar/{id}/Items
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "items":[
        {
            "name": "Woah",
            "desc": "Oh no",
            "qty": 1,
            "weight": 154,
            "cost": 14,
            "currencyDenomination": "SP"
        }
    ]
}
```

### Request url for getting ability scores

```
HTTP GET /RpgChar/{id}/AbilityScores
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "abilityScores": {
        "str": "4",
        "dex": "6",
        "con": "7",
        "int": "5",
        "wis": "3",
        "cha": "8"
    }
}
```

### Request url for getting the statuses affecting the character

```
HTTP GET /RpgChar/{id}/Status
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "status": [
        {
            "identifier": "Dead,y",
            "type": "Forcy",
            "name": "Unknown",
            "value": 13
        }
    ]
}
```

### Request url for getting hit dice

```
HTTP GET /RpgChar/{id}/HitDice
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "hitDice": [
        {
            "hitDiceUsed": 1,
            "extraHitDice": 0
        }
    ]
}
```

### Request url for getting health

```
HTTP GET /RpgChar/{id}/Health
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "health": {
        "maxHitpoints": 6,
        "tempHitpoints": 2,
        "damage": 1
    }
}
```

### Request url for getting saving throws

```
HTTP GET /RpgChar/{id}/SavingThrows
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "savingThrows": [
        {
            "name": "Dex",
            "proficiency": true
        },
        {
            "name": "Int",
            "proficiency": false
        }
    ]
}
```

### Request url for getting skills

```
HTTP GET /RpgChar/{id}/Skills
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "skills": [
        {
            "bonusModifier": 1,
            "name": "Prospecting",
            "abilityScore": "Wis",
            "proficiencyModifier": 2
        }
    ]
}
```

### Request url for getting hit dice type

```
HTTP GET /RpgChar/{id}/HitDiceType
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "hitDiceType": [
        {
            "hitDiceType": "d8"
        }
    ]
}
```

### Request url for getting death saves

```
HTTP GET /RpgChar/{id}/DeathSave
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "deathSave": [
        {
            "deathSaveSuccess": false,
            "deathSaveFailure": true
        },
        {
            "deathSaveSuccess": true,
            "deathSaveFailure": false
        }
    ]
}
```

### Request url for getting treaures

```
HTTP GET /RpgChar/{id}/Treasure
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "treasure": [
        {
            "platinum": "1",
            "gold": "0",
            "electrum": "4",
            "silver": "0",
            "copper": "0"
        }
    ]
}
```

### Request url for getting the character appearance

```
HTTP GET /RpgChar/{id}/CharacterAppearance
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "characterAppearance": [
        {
            "height": "Height",
            "weight": "Weight",
            "hairColor": "Hair",
            "eyeColor": "Eye",
            "skinColor": "Skin"
        }
    ]
}
```

### Request url for getting features and traits

```
HTTP GET /RpgChar/{id}/FeaturesTraits
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "featuresTraits": [
        {
            "background": "Noble",
            "ideals": "Few",
            "flaws": "Very",
            "bonds": "Bondy bond"
        }
    ]
}
```

### Request url for getting equipment

```
HTTP GET /RpgChar/{id}/Equipment
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "equipment": {
        "weapons": [
            {
                "name": "Weapon",
                "type": "Type",
                "dmg": "2d6",
                "handedness": "Left",
                "proficiencyModifier": 0.5,
                "price": 1,
                "currencyDenomination": "d",
                "hit": -1,
                "toHitModifier": -1,
                "weight": 1,
                "range": "5ft",
                "damageType": "Force",
                "property": "Prop",
                "description": "Lightsaber",
                "quantity": 1
            }
        ],
        "armor": [
            {
                "name": "Name",
                "type": "Type",
                "price": 1,
                "magicalModifier": 1,
                "currencyDenomination": "What",
                "weight": 12,
                "class": 11,
                "stealth": "1",
                "description": "Desc",
                "equipped": "eq"
            }
        ]
    }
}
```

### Request url for getting magic items

```
HTTP GET /RpgChar/{id}/MagicItems
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "magicItems": [
        {
            "name": "Boy",
            "type": "Unknown",
            "rarity": "Legendary",
            "requiresAttunement": true,
            "attuned": true,
            "maxCharges": 1,
            "charges": 0,
            "weight": 14,
            "description": "No ide"
        }
    ]
}
```

### Request url for getting notes

```
HTTP GET /RpgChar/{id}/Notes
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "notes": [
        {
            "text": "Test text",
            "isSavedChatNotes": true
        }
    ]
}
```

### Request url for getting spells

```
HTTP GET /RpgChar/{id}/Spells
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "spells": {
        "spellcastingAbility": "All so fuck you",
        "spellSaveDc": 19,
        "spellAttackBonus": 42,
        "spellsKnown": 1,
        "cantripsKnown": 1,
        "invocationsKnown": 1,
        "maxPrepared": 13,
        "spellSlots": [
            {
                "level": 1,
                "usedSpellSlots": 0,
                "resetsOn": "Seconds",
                "availableSpellSlots": 0
            }
        ],
        "spellList": [
            {
                "name": "Lie",
                "prepared": true,
                "alwaysPrepared": true,
                "type": "All",
                "saveAttr": "Int",
                "dmg": "6d8",
                "dmgType": "Psycic",
                "school": "Godlike",
                "level": 99,
                "description": "Tells a lie",
                "castingTime": "1 turn",
                "range": "32ft",
                "components": "Verbal",
                "duration": "Lifetime",
                "materialComponents": "None",
                "isRitual": false
            }
        ],
        "cantrips": [
            {
                "name": "Lie",
                "type": "All",
                "saveAttr": "Int",
                "dmg": "6d8",
                "dmgType": "Psycic",
                "school": "Godlike",
                "description": "Tells a lie",
                "castingTime": "1 turn",
                "range": "32ft",
                "components": "Verbal",
                "duration": "Lifetime",
                "materialComponents": "None",
                "isRitual": false
            }
        ]
    }
}
```

### Request url for getting feats

```
HTTP GET /RpgChar/{id}/Feats
```

### Response

```
Responsecode 200 OK
Content-Type: application/json
{
    "feats": [
        {
            "name": "Halfling nibleness",
            "description": "Allows you to sneak past friends"
        }
    ]
}
```

## Setting data on a character

The following methods are all sub methods on a `RpgChar` for setting fields, they all use the `PATCH` verb and only fields passed inn will be updated.
The structure is the same as for getting parts and they all compliment them, the return of all api methods are the updated part.
Meaning if you update the `health` of a character using `HTTP PATCH /RpgChar/{id}/Health` you will get in return the same object as if you called `HTTP GET /RpgChar/{id}/Health`.

### Available urls

```
HTTP PATCH /RpgChar/{id}/Profile
HTTP PATCH /RpgChar/{id}/Traits
HTTP PATCH /RpgChar/{id}/Items
HTTP PATCH /RpgChar/{id}/AbilityScores
HTTP PATCH /RpgChar/{id}/Status
HTTP PATCH /RpgChar/{id}/HitDice
HTTP PATCH /RpgChar/{id}/Health
HTTP PATCH /RpgChar/{id}/SavingThrows
HTTP PATCH /RpgChar/{id}/Skills
HTTP PATCH /RpgChar/{id}/HitDiceType
HTTP PATCH /RpgChar/{id}/DeathSave
HTTP PATCH /RpgChar/{id}/Treasure
HTTP PATCH /RpgChar/{id}/CharacterAppearance
HTTP PATCH /RpgChar/{id}/FeaturesTraits
HTTP PATCH /RpgChar/{id}/Equipment
HTTP PATCH /RpgChar/{id}/MagicItems
HTTP PATCH /RpgChar/{id}/Notes
HTTP PATCH /RpgChar/{id}/Spells
HTTP PATCH /RpgChar/{id}/Feats
```

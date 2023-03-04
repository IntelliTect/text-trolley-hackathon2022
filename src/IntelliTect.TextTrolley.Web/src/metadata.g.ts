import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const ApplicationUser = domain.types.ApplicationUser = {
  name: "ApplicationUser",
  displayName: "Application User",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "ApplicationUser",
  get keyProp() { return this.props.applicationUserId }, 
  behaviorFlags: 7,
  props: {
    applicationUserId: {
      name: "applicationUserId",
      displayName: "Application User Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
        maxLength: val => !val || val.length <= 150 || "Name may not be more than 150 characters.",
      }
    },
    id: {
      name: "id",
      displayName: "Id",
      type: "string",
      role: "primaryKey",
      hidden: 3,
    },
    userName: {
      name: "userName",
      displayName: "User Name",
      type: "string",
      role: "value",
    },
    normalizedUserName: {
      name: "normalizedUserName",
      displayName: "Normalized User Name",
      type: "string",
      role: "value",
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      role: "value",
    },
    normalizedEmail: {
      name: "normalizedEmail",
      displayName: "Normalized Email",
      type: "string",
      role: "value",
    },
    emailConfirmed: {
      name: "emailConfirmed",
      displayName: "Email Confirmed",
      type: "boolean",
      role: "value",
    },
    passwordHash: {
      name: "passwordHash",
      displayName: "Password Hash",
      type: "string",
      role: "value",
    },
    securityStamp: {
      name: "securityStamp",
      displayName: "Security Stamp",
      type: "string",
      role: "value",
    },
    concurrencyStamp: {
      name: "concurrencyStamp",
      displayName: "Concurrency Stamp",
      type: "string",
      role: "value",
    },
    phoneNumber: {
      name: "phoneNumber",
      displayName: "Phone Number",
      type: "string",
      role: "value",
    },
    phoneNumberConfirmed: {
      name: "phoneNumberConfirmed",
      displayName: "Phone Number Confirmed",
      type: "boolean",
      role: "value",
    },
    twoFactorEnabled: {
      name: "twoFactorEnabled",
      displayName: "Two Factor Enabled",
      type: "boolean",
      role: "value",
    },
    lockoutEnd: {
      name: "lockoutEnd",
      displayName: "Lockout End",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
    lockoutEnabled: {
      name: "lockoutEnabled",
      displayName: "Lockout Enabled",
      type: "boolean",
      role: "value",
    },
    accessFailedCount: {
      name: "accessFailedCount",
      displayName: "Access Failed Count",
      type: "number",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Requester = domain.types.Requester = {
  name: "Requester",
  displayName: "Requester",
  get displayProp() { return this.props.requesterId }, 
  type: "model",
  controllerRoute: "Requester",
  get keyProp() { return this.props.requesterId }, 
  behaviorFlags: 7,
  props: {
    requesterId: {
      name: "requesterId",
      displayName: "Requester Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    requesterName: {
      name: "requesterName",
      displayName: "Requester Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Requester Name is required.",
        minLength: val => !val || val.length >= 2 || "Requester Name must be at least 2 characters.",
        maxLength: val => !val || val.length <= 100 || "Requester Name may not be more than 100 characters.",
      }
    },
    requesterNumber: {
      name: "requesterNumber",
      displayName: "Requester Number",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Requester Number is required.",
        maxLength: val => !val || val.length <= 30 || "Requester Number may not be more than 30 characters.",
        phone: val => !val || /^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/.test(val.replace(/\s+/g, '')) || "Requester Number must be a valid US phone number.",
      }
    },
    activeShoppingListKey: {
      name: "activeShoppingListKey",
      displayName: "Active Shopping List Key",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.ShoppingList as ModelType).props.shoppingListId as PrimaryKeyProperty },
      get principalType() { return (domain.types.ShoppingList as ModelType) },
      get navigationProp() { return (domain.types.Requester as ModelType).props.activeShoppingList as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Active Shopping List is required.",
      }
    },
    activeShoppingList: {
      name: "activeShoppingList",
      displayName: "Active Shopping List",
      type: "model",
      get typeDef() { return (domain.types.ShoppingList as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Requester as ModelType).props.activeShoppingListKey as ForeignKeyProperty },
      get principalKey() { return (domain.types.ShoppingList as ModelType).props.shoppingListId as PrimaryKeyProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const ShoppingList = domain.types.ShoppingList = {
  name: "ShoppingList",
  displayName: "Shopping List",
  get displayProp() { return this.props.shoppingListId }, 
  type: "model",
  controllerRoute: "ShoppingList",
  get keyProp() { return this.props.shoppingListId }, 
  behaviorFlags: 7,
  props: {
    shoppingListId: {
      name: "shoppingListId",
      displayName: "Shopping List Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    requester: {
      name: "requester",
      displayName: "Requester",
      type: "model",
      get typeDef() { return (domain.types.Requester as ModelType) },
      role: "value",
      dontSerialize: true,
    },
    applicationUsers: {
      name: "applicationUsers",
      displayName: "Application Users",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.ApplicationUser as ModelType) },
      },
      role: "value",
      dontSerialize: true,
    },
    items: {
      name: "items",
      displayName: "Items",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.ShoppingListItem as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.ShoppingListItem as ModelType).props.shoppingListId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.ShoppingListItem as ModelType).props.shoppingList as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    isComplete: {
      name: "isComplete",
      displayName: "Is Complete",
      type: "boolean",
      role: "value",
    },
    isDelivered: {
      name: "isDelivered",
      displayName: "Is Delivered",
      type: "boolean",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const ShoppingListItem = domain.types.ShoppingListItem = {
  name: "ShoppingListItem",
  displayName: "Shopping List Item",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "ShoppingListItem",
  get keyProp() { return this.props.shoppingListItemId }, 
  behaviorFlags: 7,
  props: {
    shoppingListItemId: {
      name: "shoppingListItemId",
      displayName: "Shopping List Item Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
        maxLength: val => !val || val.length <= 1024 || "Name may not be more than 1024 characters.",
      }
    },
    originalName: {
      name: "originalName",
      displayName: "Original Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Original Name is required.",
      }
    },
    shoppingListId: {
      name: "shoppingListId",
      displayName: "Shopping List Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.ShoppingList as ModelType).props.shoppingListId as PrimaryKeyProperty },
      get principalType() { return (domain.types.ShoppingList as ModelType) },
      get navigationProp() { return (domain.types.ShoppingListItem as ModelType).props.shoppingList as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Shopping List is required.",
      }
    },
    shoppingList: {
      name: "shoppingList",
      displayName: "Shopping List",
      type: "model",
      get typeDef() { return (domain.types.ShoppingList as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.ShoppingListItem as ModelType).props.shoppingListId as ForeignKeyProperty },
      get principalKey() { return (domain.types.ShoppingList as ModelType).props.shoppingListId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.ShoppingList as ModelType).props.items as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    purchased: {
      name: "purchased",
      displayName: "Purchased",
      type: "boolean",
      role: "value",
      rules: {
        required: val => val != null || "Purchased is required.",
      }
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const LoginService = domain.services.LoginService = {
  name: "LoginService",
  displayName: "Login Service",
  type: "service",
  controllerRoute: "LoginService",
  methods: {
    loginUser: {
      name: "loginUser",
      displayName: "Login User",
      transportType: "item",
      httpMethod: "POST",
      params: {
        email: {
          name: "email",
          displayName: "Email",
          type: "string",
          role: "value",
        },
        password: {
          name: "password",
          displayName: "Password",
          type: "string",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    registerUser: {
      name: "registerUser",
      displayName: "Register User",
      transportType: "item",
      httpMethod: "POST",
      params: {
        firstName: {
          name: "firstName",
          displayName: "First Name",
          type: "string",
          role: "value",
        },
        lastName: {
          name: "lastName",
          displayName: "Last Name",
          type: "string",
          role: "value",
        },
        email: {
          name: "email",
          displayName: "Email",
          type: "string",
          role: "value",
        },
        password: {
          name: "password",
          displayName: "Password",
          type: "string",
          role: "value",
        },
        phoneNumber: {
          name: "phoneNumber",
          displayName: "Phone Number",
          type: "string",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    ApplicationUser: typeof ApplicationUser
    Requester: typeof Requester
    ShoppingList: typeof ShoppingList
    ShoppingListItem: typeof ShoppingListItem
  }
  services: {
    LoginService: typeof LoginService
  }
}

solidify(domain)

export default domain as unknown as AppDomain

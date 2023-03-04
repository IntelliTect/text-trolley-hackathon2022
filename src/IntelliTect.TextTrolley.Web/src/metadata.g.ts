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
      }
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
        phone: val => !val || /^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/.test(val.replace(/\s+/g, '')) || "Requester Number must be a valid US phone number.",
      }
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
    requesterId: {
      name: "requesterId",
      displayName: "Requester Id",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Requester Id is required.",
      }
    },
    applicationUserIds: {
      name: "applicationUserIds",
      displayName: "Application User Ids",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "number",
      },
      role: "value",
      rules: {
        required: val => val != null || "Application User Ids is required.",
      }
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
        minLength: val => !val || val.length >= 2 || "Name must be at least 2 characters.",
        maxLength: val => !val || val.length <= 100 || "Name may not be more than 100 characters.",
      }
    },
    shoppingListId: {
      name: "shoppingListId",
      displayName: "Shopping List Id",
      type: "number",
      role: "value",
      rules: {
        required: val => val != null || "Shopping List Id is required.",
      }
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
  }
}

solidify(domain)

export default domain as unknown as AppDomain

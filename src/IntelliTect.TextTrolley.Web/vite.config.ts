import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from "vite";

import createVuePlugin from "@vitejs/plugin-vue";
import createCheckerPlugin from "vite-plugin-checker";
import { createAspNetCoreHmrPlugin } from "coalesce-vue/lib/build";
import createAutoImport from 'unplugin-auto-import/vite'

import createVueComponentImporterPlugin from "unplugin-vue-components/vite";
import { CoalesceVuetifyResolver } from "coalesce-vue-vuetify3/build";
import { Vuetify3Resolver } from "unplugin-vue-components/resolvers";

export default defineConfig(async ({ command, mode }) => {
  return {
    build: {
      outDir: "wwwroot",
      rollupOptions: {
        output: {
          manualChunks(id) {
            if (id.match(/home/i)) return "index";
            // All views are chunked together so that dynamic imports can be
            // used in `router.ts`(which makes for a much more readable file).
            // Without this, each dynamic import would get its own chunk.
            if (id.includes("views")) return "views";
            return "index";
          },
        },
      },
    },

    plugins: [
      createAutoImport({
        imports: [
          'vue',
          'vue-router'
        ],
        dirs: [
          './src/composables/*'
        ],

      }),

      createVuePlugin(),

      // Transforms usages of Vuetify and Coalesce components into treeshakable imports.
      // Vuetify3Resolved could be removed and replaced by vite-plugin-vuetify if desired.
      createVueComponentImporterPlugin({
        resolvers: [Vuetify3Resolver(), CoalesceVuetifyResolver()],
      }),

      // Integrations with UseViteDevelopmentServer from IntelliTect.Coalesce.Vue
      createAspNetCoreHmrPlugin(),

      // Perform type checking during development and build time.
      // Disable during test (vitest) because it isn't capable of emitting errors to vitest.
      mode !== "test" &&
        createCheckerPlugin({
          vueTsc: {
            // Special tsconfig to avoid performing typechecking on test files
            // when running the development server
            tsconfigPath: "tsconfig.dev.json",
          },
        }),
    ],

    resolve: {
      alias: {
        // Allow imports prefixed with "@" to be relative to the src folder.
        '@': fileURLToPath(new URL('./src', import.meta.url))
      },
    },

    test: {
      globals: true,
      environment: "happy-dom",
      setupFiles: ["tests/setupTests.ts"],
      coverage: {
        exclude: ["**/*.g.ts", "test{,s}/**"],
      },
      deps: {
        inline: ["vuetify"],
      },
    },
  };
});
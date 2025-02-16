<script setup lang="ts">
import { ref } from 'vue'
import { RouterView } from 'vue-router'
const drawer = ref(true)
</script>

<template>
  <q-layout view="hHh Lpr lff">
    <q-header elavated>
      <q-toolbar>
        <q-btn flat @click="drawer = !drawer" round dense icon="menu" />
        <q-toolbar-title>Header</q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-drawer v-model="drawer" show-if-above :width="200" :breakpoint="500" bordered>
      <q-scroll-area class="fit">
        <q-list>
          <q-item to="/" clickable :active="true" v-ripple>
            <q-item-section avatar>
              <q-icon name="inbox" />
            </q-item-section>
            <q-item-section> Home </q-item-section>
          </q-item>
          <q-separator />
        </q-list>
      </q-scroll-area>
    </q-drawer>

    <q-page-container>
      <RouterView />
    </q-page-container>
  </q-layout>
</template>

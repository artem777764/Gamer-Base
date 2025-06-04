<script setup lang="ts">
import MySearch from '@/components/MySearch.vue';
import api from '@/lib/axios';
import router from '@/router';
import type { IFilterItem } from '@/types/filter';
import { onMounted, ref } from 'vue';

const query = ref()

const handleSearch = () => {
  const q: Record<string, string> = {}

  q.query = query.value || ''

  if (selectedGenreId.value != null) {
    q.genreId = String(selectedGenreId.value)
  }

  if (selectedPlatformId.value != null) {
    q.platformId = String(selectedPlatformId.value)
  }

  if (selectedDeveloperId.value != null) {
    q.developerId = String(selectedDeveloperId.value)
  }

  if (selectedPublisherId.value != null) {
    q.publisherId = String(selectedPublisherId.value)
  }

  router.push({
    name: 'SearchResult',
    query: q,
  })
}

const genres = ref<IFilterItem[]>([])
const platforms = ref<IFilterItem[]>([])
const developers = ref<IFilterItem[]>([])
const publishers = ref<IFilterItem[]>([])

const selectedGenreId = ref()
const selectedPlatformId = ref()
const selectedDeveloperId = ref()
const selectedPublisherId = ref()

async function fetchGenres() {
    try {
        genres.value = (await api.get('/Genres')).data
    } catch (error) {
        console.log('Ошибка загрузки жанров');
    }
}

async function fetchPlatforms() {
    try {
        platforms.value = (await api.get('/Platforms')).data
    } catch (error) {
        console.log('Ошибка загрузки платформ');
    }   
}

async function fetchDevelopers() {
    try {
        developers.value = (await api.get('/Developers')).data
    } catch (error) {
        console.log('Ошибка загрузки разработчиков');
    }
}

async function fetchPublishers() {
    try {
        publishers.value = (await api.get('/Publishers')).data
    } catch (error) {
        console.log('Ошибка загрузки издателей');
    }
}

onMounted(() => {
  fetchGenres()
  fetchPlatforms()
  fetchDevelopers()
  fetchPublishers()
})

</script>

<template>
  <div class="fixed inset-0 -z-10">
    <div 
      class="absolute inset-0 bg-[url('/images/SearchPageBackground.png')] bg-no-repeat bg-cover bg-center"
    ></div>
  </div>
  
  <div class="relative min-h-screen overflow-hidden mx-5">
    <div class="absolute top-[200px] shadow-md w-full">
      <MySearch
        v-model="query"
        v-model:selected-genre-id="selectedGenreId"
        v-model:selected-platform-id="selectedPlatformId"
        v-model:selected-developer-id="selectedDeveloperId"
        v-model:selected-publisher-id="selectedPublisherId"
        @submit="handleSearch"
        font-size="text-7xl"
        placeholder="Поиск..."
        :genres="genres"
        :platforms="platforms"
        :developers="developers"
        :publishers="publishers"/>
      />
    </div>
  </div>
</template>

<style scoped>
html, body {
  overflow: hidden;
  margin: 0;
  height: 100%;
}
</style>
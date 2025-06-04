<script setup lang="ts">
import { onMounted, ref, watch } from 'vue';
import Card from '@/components/Card.vue';
import MySearch from '@/components/MySearch.vue';
import { useRoute } from 'vue-router';
import type { IFilterItem } from '@/types/filter';
import api from '@/lib/axios';

const route = useRoute()
const name = ref((route.query.query as string) || '')
const selectedGenreId = ref<number | null>(
  route.query.genreId ? Number(route.query.genreId) : null
)
const selectedPlatformId = ref<number | null>(
  route.query.platformId ? Number(route.query.platformId) : null
)
const selectedDeveloperId= ref<number | null>(
  route.query.developerId? Number(route.query.developerId): null
)
const selectedPublisherId= ref<number | null>(
  route.query.publisherId? Number(route.query.publisherId): null
)

interface Game {
  Id: number
  Rating: number,
  ImageURL: string
}

const games = ref<Game[]>([])
const genres = ref<IFilterItem[]>([])
const platforms = ref<IFilterItem[]>([])
const developers = ref<IFilterItem[]>([])
const publishers = ref<IFilterItem[]>([])

let debounceTimeout: number | undefined
watch([name, selectedGenreId, selectedPlatformId, selectedDeveloperId, selectedPublisherId],
 ([newName, newGenreId, newPlatformId, newDeveloperId, newPublisherId]) => {
    clearTimeout(debounceTimeout);

    debounceTimeout = window.setTimeout(() => {
        page.value = 1;
        allLoaded.value = false;
        fetchGames(newName, newGenreId, newPlatformId, newDeveloperId, newPublisherId);
    }, 200);
});

const page = ref(1)
const pageSize = 4
const isLoading = ref(false)
const allLoaded = ref(false)
const observerRef = ref<HTMLElement | null>(null)

async function fetchGames(
    name: string,
    genreId: number | null,
    platformId: number | null,
    developerId: number | null,
    publisherId: number | null,
    append = false
) {
    if (isLoading.value || allLoaded.value) return;

    isLoading.value = true;

    try {
        const response = await api.post(
        '/Games/Search',
        {
            Name: name,
            PlatformId: platformId,
            GenreId: genreId,
            DeveloperId: developerId,
            PublisherId: publisherId,
        },
        {
            params: {
                page: page.value,
                size: pageSize
            }
        });

        const newGames = response.data;
        if (newGames.length < pageSize) {
            allLoaded.value = true;
        }
        if (append) {
            games.value.push(...newGames);
        } else {
            games.value = newGames;
        }
    } catch (error) {
        console.error('Ошибка при загрузке игр:', error);
    } finally {
        isLoading.value = false;
    }
}

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

function createObserver() {
    const observer = new IntersectionObserver((entries) => {
        const entry = entries[0];

        if (entry.isIntersecting && !isLoading.value && !allLoaded.value) {
            page.value++;
            fetchGames(name.value, selectedGenreId.value, selectedPlatformId.value, selectedDeveloperId.value, selectedPublisherId.value, true);
        }
    }, {
        root: null,
        threshold: 0.1
    });

    if (observerRef.value) {
        observer.observe(observerRef.value);
    }
}

onMounted(() => {
  fetchGames(name.value, selectedGenreId.value, selectedPlatformId.value, selectedDeveloperId.value, selectedPublisherId.value)
  fetchGenres()
  fetchPlatforms()
  fetchDevelopers()
  fetchPublishers()
  createObserver()
})

</script>

<template>
    <div class="min-h-screen bg-background">
        <MySearch
            v-model:model-value="name"
            v-model:selected-genre-id="selectedGenreId"
            v-model:selected-platform-id="selectedPlatformId"
            v-model:selected-developer-id="selectedDeveloperId"
            v-model:selected-publisher-id="selectedPublisherId"
            font-size="text-5xl"
            placeholder="Поиск..."
            :genres="genres"
            :platforms="platforms"
            :developers="developers"
            :publishers="publishers"/>
        <div class="grid grid-cols-4 gap-x-5 px-5 pt-5">
            <div v-for="game in games"
                :key="game.Id"
                :to="`/game-info/${game.Id}`"
                class="mb-5 w-full block">
                <a :href="`/game-info/${game.Id}`" target="_blank" rel="noopener">
                    <Card :image-src="game.ImageURL" class="w-full"/>
                </a>
                <div v-if="game.Rating">
                    <a :href="`/game-review/${game.Id}`" target="_blank" rel="noopener">
                        <p class="font-russo leading-none text-shadow text-white text-3xl underline mt-1 text-center">{{game.Rating.toFixed(2)}}/5.00</p>
                    </a>
                </div>
                <div v-else>
                    <a :href="`/game-review/${game.Id}`" target="_blank" rel="noopener">
                        <p class="font-russo leading-none text-shadow text-gray-400 text-3xl underline mt-1 text-center">Нет отзывов</p>
                    </a>
                </div>
            </div>
        </div>
        <div ref="observerRef" class="h-[1px] w-full"></div>
    </div>
</template>
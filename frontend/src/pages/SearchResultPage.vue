<script setup lang="ts">
import { onMounted, ref, watch } from 'vue';
import axios from 'axios'
import Card from '@/components/Card.vue';
import MySearch from '@/components/MySearch.vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const name = ref(route.params.query as string)

interface Game {
  Id: number
  Rating: number,
  ImageURL: string
}

const games = ref<Game[]>([])

let debounceTimeout: number | undefined
watch(name, (newName: string) => {
    clearTimeout(debounceTimeout);

    debounceTimeout = window.setTimeout(() => {
        page.value = 1;
        allLoaded.value = false;
        fetchGames(newName);
    }, 200);
});

const page = ref(1)
const pageSize = 4
const isLoading = ref(false)
const allLoaded = ref(false)
const observerRef = ref<HTMLElement | null>(null)

async function fetchGames(name: string, append = false){
    if (isLoading.value || allLoaded.value) return;

    isLoading.value = true;

    try {
        const response = await axios.post(
        'http://localhost:5007/Games/Search',
        {
            Name: name
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

function createObserver() {
    const observer = new IntersectionObserver((entries) => {
        const entry = entries[0];

        if (entry.isIntersecting && !isLoading.value && !allLoaded.value) {
            page.value++;
            fetchGames(name.value, true);
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
  fetchGames(name.value)
  createObserver()
})

</script>

<template>
    <div class="min-h-screen bg-background">
        <MySearch v-model="name" font-size="text-5xl" placeholder="Поиск..."/>
        <div class="grid grid-cols-4 gap-x-5 px-5 pt-5">
            <div v-for="game in games"
                :key="game.Id"
                :to="`/game-info/${game.Id}`"
                class="mb-5 w-full block">
                <router-link :to="`/game-info/${game.Id}`">
                    <Card :image-src="game.ImageURL" class="w-full"/>
                </router-link>
                <div v-if="game.Rating">
                    <router-link :to="{ name: 'GameReview', params: { id: game.Id } }">
                        <p class="font-russo leading-none text-shadow text-white text-3xl underline mt-1 text-center">{{game.Rating.toFixed(2)}}/5.00</p>
                    </router-link>
                </div>
                <div v-else>
                    <router-link :to="{ name: 'GameReview', params: { id: game.Id } }">
                        <p class="font-russo leading-none text-shadow text-gray-400 text-3xl underline mt-1 text-center">Нет отзывов</p>
                    </router-link>
                </div>
            </div>
        </div>
        <div ref="observerRef" class="h-[1px] w-full"></div>
    </div>
</template>
<script setup lang="ts">
import type { IComment } from '@/types/comment';
import Card from '@/components/Card.vue';

defineProps<{
    comment: IComment
}>()
</script>

<template>
    <div class="p-5 flex flex-col gap-3">
        <div class="flex flex-row place-content-between">
            <div class="flex flex-row gap-2 items-center">
                <Card :image-src="comment.UserImageURL" aspect='aspect-[1/1]' class="w-[54px]"/>
                <div class="flex flex-col gap-2">
                    <p class="font-russo leading-none text-shadow text-lg, text-white">{{ comment.UserName }}</p>
                    <p v-if="comment.UserMark" class="font-russo leading-none text-shadow text-base text-white">{{ comment.UserMark.toFixed(2) }}/5.00</p>
                    <p v-else class="font-russo leading-none text-shadow text-base text-white">Оценки нет</p>
                </div>
            </div>
            <div>
                <p class="font-russo leading-none text-shadow text-white">{{ comment.Rating }}</p>
            </div>
        </div>
        <div class="flex flex-col gap-2">
            <p class="font-russo leading-none text-shadow text-base text-white text-justify">{{ comment.Content }}</p>
        </div>
    </div>
</template>